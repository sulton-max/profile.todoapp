<template>
    <div>
        <AppDashboard />
        <AuthModal />
    </div>
</template>

<script lang="ts">
import AppDashboard from '@/views/Dashboard.vue';
import AuthModal from "@/components/AuthModal.vue";

export default {
    name: 'App',
    components: {
        AppDashboard,
        AuthModal,
    }
}
</script>