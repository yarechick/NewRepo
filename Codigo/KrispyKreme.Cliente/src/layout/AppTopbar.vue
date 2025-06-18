<script setup>
import { useLayout } from '@/layout/composables/layout';
import AppConfigurator from './AppConfigurator.vue';

const { toggleMenu, toggleDarkMode, isDarkTheme } = useLayout();
</script>

<template>
    <div class="layout-topbar">
        <div class="layout-topbar-logo-container">
            <button class="layout-menu-button layout-topbar-action" @click="toggleMenu">
                <i class="pi pi-bars"></i>
            </button>
            <router-link to="/pages/crud" class="layout-topbar-logo">
                <svg width="200" height="200" viewBox="0 0 200 200" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <circle cx="100" cy="100" r="90" stroke="#50C878" stroke-width="6" fill="none" stroke-linecap="round" stroke-dasharray="2,3" />
                    <circle cx="100" cy="100" r="35" stroke="#50C878" stroke-width="6" fill="none" stroke-linecap="round" stroke-dasharray="2,3" />
                    <path d="M60 80 C65 75, 70 85, 75 80 S85 70, 90 75 S100 85, 110 80 S130 85, 135 75" stroke="#50C878" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-dasharray="2,3" />
                </svg>

                <span>Donas!</span>
            </router-link>
        </div>

        <div class="layout-topbar-actions">
            <div class="layout-topbar-menu hidden lg:block">
                <div class="layout-topbar-menu-content">
                    <button class="layout-topbar-action" @click="$router.push('/auth/Login')">
                        <i class="pi pi-user"></i>
                        <span>Usuario</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>
