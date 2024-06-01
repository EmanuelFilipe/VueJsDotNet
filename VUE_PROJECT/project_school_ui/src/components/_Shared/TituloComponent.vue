<template>
    <div>
        <div style="display: flex; width: 50%;">
            <h2>{{ titulo }}</h2>
            <div class="voltar">
                <slot></slot>
                <button v-show="btnVoltar" class="btn btnVoltar" @click="Voltar()">Voltar</button>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            titulo: String,
            btnVoltar: Boolean
        },
        methods: {
            Voltar(){
                this.$router.back()
            }
        }
    }
</script>

<style scoped>
.voltar {
    width: 50%;
    position: absolute;
    margin-top: 15px;
}

.btnVoltar {
    float: right;
    background-color: rgb(199, 199, 199);
    margin-top: 10px;
}
</style>