import { createPinia } from 'pinia';
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';

import Aura from '@primeuix/themes/aura';
import PrimeVue from 'primevue/config';
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';

import '@/assets/styles.scss';

const defaultConfig = {
    API_URL: 'https://localhost:7103'
};

const loadConfig = async () => {
    try {
        const response = await fetch('/config.json');

        if (!response.ok || response.status === 204) {
            throw new Error('Empty or invalid response');
        }

        const contentType = response.headers.get('content-type');
        if (!contentType || !contentType.includes('application/json')) {
            throw new Error('Invalid content type');
        }

        return await response.json();
    } catch (error) {
        console.warn('Failed to load external config:', error);
        return null;
    }
};

const initApp = async () => {
    // 1. Primero cargamos la configuración
    const externalConfig = await loadConfig();
    const finalConfig = externalConfig ? { ...defaultConfig, ...externalConfig } : defaultConfig;

    // 2. Creamos la instancia de la aplicación
    const app = createApp(App);

    // 3. Hacemos disponible la configuración globalmente
    app.config.globalProperties.$config = finalConfig;
    app.provide('config', finalConfig);

    // 4. Registramos todos los plugins
    app.use(router); // Router debe registrarse antes de montar
    app.use(createPinia());

    app.use(PrimeVue, {
        theme: {
            preset: Aura,
            options: {
                darkModeSelector: '.app-dark'
            }
        }
    });

    app.use(ToastService);
    app.use(ConfirmationService);

    // 5. Finalmente montamos la aplicación
    app.mount('#app');
};

initApp();
