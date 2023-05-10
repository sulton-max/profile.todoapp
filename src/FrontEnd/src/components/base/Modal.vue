<template>
    <div class="dark modal-background cover-absolute bg-black dark:bg-black bg-opacity-90 flex items-center justify-center">
        <div class="modal container-border relative w-full md:w-fit m-6 p-6 md:px-20 rounded-2xl bg-white dark:bg-dark-primary dark:text-dark-text-primary ">
            <button class="group absolute
            top-3 right-3

            hidden md:flex items-center
            justify-center
            mb-4 w-8 h-8
            rounded-full
            border-2 bg-mono-primary hover:bg-mono-secondary hover:border-mono-secondary dark:hover:bg-dark-accent-primary dark:hover:border-dark-accent-primary dark:bg-dark-primary dark:border-mono-secondary duration-200">
                <i class="fas fa-xmark text-dark-secondary dark:text-mono-secondary dark:group-hover:text-dark-primary"></i>
            </button>
            <slot name="content"></slot>
        </div>
    </div>
</template>

<script lang="ts">
import {watch} from "vue";

export default {
    name: 'AppModal',
    props: {
        show: {
            required: true,
        },
        scrollable: {
            default: false
        }
    },
    setup(props: any) {

        console.log(props.show);

        // lifecycle hooks

        // watchers
        // disables scrolling
        watch(props.show, (newValue, oldValue) => {
            console.log(newValue, props.scrollable);
            if (newValue && !props.scrollable) {
                console.log('watching');
                document.body.style.setProperty('overflow', 'hidden');
            } else {
                document.body.style.removeProperty('overflow');
            }
        }, {immediate: true});
    }
}

</script>