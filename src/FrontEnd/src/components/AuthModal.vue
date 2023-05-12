<template>
    <teleport to="body">
        <app-modal :show="true">
            <template v-slot:content>
                <h5>Auth Modal Content</h5>
            </template>
        </app-modal>
    </teleport>
</template>

<script lang="ts">
import AppModal from "@/components/base/Modal.vue";

export default {
    name: 'AppAuthModal',
    components: {
        AppModal,
    }
}
</script>
