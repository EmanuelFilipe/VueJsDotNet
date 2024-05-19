<template>
  <div>
    <TituloComponent titulo="Aluno" />
    <div>
      <input class="form-control" type="text" placeholder="Nome do Aluno" v-model="nome"
      v-on:keyup.enter="addAluno()">
      <button class="btn btnInput" @click="addAluno()"> Adicionar</button>
    </div>
    <br>
    <div>
      <table class="table">
        <thead>
          <th>Mat.</th>
          <th>Nome</th>
          <th>Opções</th>
        </thead>
        <tbody v-if="alunos.length">
          <tr v-for="(aluno, index) in alunos" :key="index">
            <!-- <td>{{aluno.id}}</td> -->
            <td>{{ index + 1 }}</td>
            <td>{{aluno.nome}} {{ aluno.sobrenome }}</td>
            <td>
              <button class="btn btn-danger" @click="remover(aluno)">Remover</button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <td colspan="5" style="color: red; text-align: center; padding: 10px;">Nenhum Aluno Encontrado</td></tfoot>
      </table>
    </div>
  
  </div>

</template>

<script>
import TituloComponent from './_Shared/TituloComponent.vue'

export default {
  components:{
    TituloComponent
  },
  data() {
    return {
      titulo: 'Aluno',
      nome: '',
      alunos: []
    }
  },
  created() {
    this.$http.get('http://localhost:3000/alunos')
              .then(response => response.json())
              .then(alunos => this.alunos = alunos)
  },
  props: {
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: ""
      }

      this.$http
              .post('http://localhost:3000/alunos', _aluno)
              .then(response => response.json())
              .then(aluno => {
                this.alunos.push(aluno)
                // this.alunos.forEach(aluno => {
                //   console.log(aluno)
                // });
                this.clearNome()
              })
    },
    remover(aluno){
      this.$http
              .delete(`http://localhost:3000/alunos/${aluno.id}`)
              .then(() => {
                //indíce do aluno no array
                let indice = this.alunos.indexOf(aluno);
                //apaga a partir do indice, 1 registro
                this.alunos.splice(indice, 1);
              })
    },
    clearNome() {
      this.nome = ''
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput {
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
