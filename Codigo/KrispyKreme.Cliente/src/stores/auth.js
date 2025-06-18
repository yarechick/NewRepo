import AuthService from '@/service/AuthService';
import { defineStore } from 'pinia';

export const useAuthStore = defineStore('auth', {
    state: () => ({
        isAuthenticated: validateToken() //AuthService.getToken()
    }),
    actions: {
        setAuthenticated(status) {
            this.isAuthenticated = status;
        },
        logout() {
            AuthService.logout();
            this.setAuthenticated(false);
        }
    }
});

export const validateToken = () => {
    const token = AuthService.getToken();

    if (!token) return false;

    try {
        // Decodificar el token sin verificar la firma (solo para ver expiración)
        const payload = JSON.parse(atob(token.split('.')[1]));

        // Verificar expiración (tiempo en segundos)
        const now = Math.floor(Date.now() / 1000);
        if (payload.exp < now) {
            console.warn('Token expirado');
            AuthService.logout();
            return false;
        }

        return true;
    } catch (error) {
        console.error('Token inválido:', error);
        AuthService.logout();
        return false;
    }
};
