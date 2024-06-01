<template>
    <div>
        <Titulo titulo="Sobre" />
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. At aut, repudiandae recusandae culpa illo accusamus voluptas quasi maiores velit asperiores et qui laudantium omnis rem vero delectus laborum in unde.</p>
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, labore explicabo? Nesciunt sequi, officiis labore beatae a doloribus perspiciatis numquam accusamus culpa optio fuga debitis nobis sint? Accusamus, odit repellat!</p>
    </div>
</template>

<script>
import Titulo from '../_Shared/TituloComponent.vue'

    export default {
        name: 'SobreComponent',
        components: {
            Titulo
        },
        data(){
            return {

            }
        }

    }
</script>

<style scoped>

</style>