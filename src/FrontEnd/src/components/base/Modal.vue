<template>
    <div class="modal-background absolute top-0 left-0 right-0 min-h-screen bg-black bg-opacity-80 flex items-center justify-center">
        <div class="modal-content w-full md:w-fit m-6 p-6 rounded-md bg-white">
            <slot name="content"></slot>
        </div>
    </div>
</template>

<script lang="ts">
export default {
    name: 'AppModal'
}

</script>