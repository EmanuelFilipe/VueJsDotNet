<template>
  <div>
    <TituloComponent titulo="Professores" btnVoltar="true" />
    <table class="table">
      <thead>
        <th>Cód.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td class="colPequeno">{{ professor.id }}</td>
            <router-link v-bind:to="`/alunos/${professor.id}`" tag="td" style="cursor: pointer">
              {{ professor.nome }} {{ professor.sobrenome }}
            </router-link>
          <td class="colPequeno">
            {{ professor.qtdAlunos }}
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <td colspan="5" style="color: red; text-align: center; padding: 10px">
          Nenhum Professor Encontrado
        </td>
      </tfoot>
    </table>
  </div>
</template>

<script>
import TituloComponent from '../_Shared/TituloComponent.vue'

export default {
  name: 'ProfessorComponent',
  components: {
    TituloComponent
  },
  data() {
    return {
      Professores: [],
      Alunos: []
    };
  },
  created() {
    this.$http.get('http://localhost:5211/api/aluno')
              .then(response => response.json())
              .then(alunos => {
                this.Alunos = alunos
                this.carregarProfessores()
              })
  },
  props: {
  },
  methods: {
    pegarQtdAlunosPorProfessor(){
      this.Professores.forEach((p, index) => {
        let professor = {
          id: p.id,
          nome: p.nome,
          qtdAlunos: this.Alunos.filter(aluno => aluno.professor.id == p.id).length
        }
        this.Professores[index] = professor
      })
    },
    carregarProfessores() {
      this.$http.get('http://localhost:5211/api/professor')
                .then(response => response.json())
                .then(professores => {
                  this.Professores = professores
                  this.pegarQtdAlunosPorProfessor()
                })
    }
  }
};
</script>

<style scoped>
.colPequeno {
  text-align: center;
  width: 17%;
}
</style>
