<script update>
import { useAuthStore } from '@/stores/auth';
import AuthService from '@/service/AuthService';
import { inject, ref, onMounted } from 'vue';

//const config = inject('config');
//const API_URL = ref('');
const API_URL = 'https://localhost:7254/';

/*onMounted(() => {
    if (config && config.API_URL) {
        API_URL.value = config.API_URL;
    } else {
        console.error('Configuración no cargada');
        // Valor por defecto temporal
        API_URL.value = 'https://localhost:7254/';
    }
});*/

export default {
    data() {
        return {
            user: {
                nombreUsuario: '',
                contrasenaHash: ''
            }
        };
    },
    methods: {
        async handleSubmit() {
            try {
                await AuthService.login(API_URL, this.user);
                const authStore = useAuthStore();
                authStore.setAuthenticated(true);
                this.$router.push('/');
            } catch (error) {
                console.error('Error de autenticación:' + API_URL, error);
                alert('Credenciales inválidas');
            }
        }
    }
};
</script>

<template>
    <form @submit.prevent="handleSubmit">
        <div class="bg-surface-50 dark:bg-surface-950 flex items-center justify-center min-h-screen min-w-[100vw] overflow-hidden">
            <div class="flex flex-col items-center justify-center">
                <div style="border-radius: 56px; padding: 0.3rem; background: linear-gradient(180deg, var(--primary-color) 10%, rgba(33, 150, 243, 0) 30%)">
                    <div class="w-full bg-surface-0 dark:bg-surface-900 py-20 px-8 sm:px-20" style="border-radius: 53px">
                        <div class="text-center mb-8" style="">
                            <div style="display: flex; justify-content: center; align-items: center">
                                <svg width="80" height="80" viewBox="0 0 200 200" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <circle cx="100" cy="100" r="90" stroke="#50C878" stroke-width="6" fill="none" stroke-linecap="round" stroke-dasharray="2,3" />
                                    <circle cx="100" cy="100" r="35" stroke="#50C878" stroke-width="6" fill="none" stroke-linecap="round" stroke-dasharray="2,3" />
                                    <path d="M60 80 C65 75, 70 85, 75 80 S85 70, 90 75 S100 85, 110 80 S130 85, 135 75" stroke="#50C878" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-dasharray="2,3" />
                                </svg>
                            </div>
                            <div class="text-surface-900 dark:text-surface-0 text-3xl font-medium mb-4">Bienvenido a Donas!</div>
                            <span class="text-muted-color font-medium">Inicia Sesión para continuar</span>
                        </div>

                        <div>
                            <label for="email1" class="block text-surface-900 dark:text-surface-0 text-xl font-medium mb-2">Usuario</label>
                            <InputText id="email1" type="text" placeholder="Usuario" class="w-full md:w-[30rem] mb-8" v-model="user.nombreUsuario" />

                            <label for="password1" class="block text-surface-900 dark:text-surface-0 font-medium text-xl mb-2">Contraseña</label>
                            <Password id="password1" v-model="user.contrasenaHash" placeholder="Contraseña" :toggleMask="true" class="mb-4" fluid :feedback="false"></Password>

                            <Button type="submit" label="Iniciar Sesión" class="w-full"></Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</template>

<style scoped>
.pi-eye {
    transform: scale(1.6);
    margin-right: 1rem;
}

.pi-eye-slash {
    transform: scale(1.6);
    margin-right: 1rem;
}
</style>
