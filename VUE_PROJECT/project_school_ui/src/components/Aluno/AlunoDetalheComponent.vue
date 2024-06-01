<template>
  <div>
    <Titulo :titulo="`Aluno: ${aluno.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="EditarFormulario()">Editar</button>
    </Titulo>
    <!-- <button class="btn btn-primary" style="color: black" @click="EditarFormulario()">
      {{ this.EditAction == true ? 'Editar' : 'Cancelar' }}
    </button> -->
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula: </td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome: </td>
          <td>
            <label v-if="visualizando">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome: </td>
          <td>
            <label v-if="visualizando">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento: </td>
          <td>
            <label v-if="visualizando">{{ aluno.dataNasc }}</label>
            <input v-else v-model="aluno.dataNasc" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor: </td>
          <td>
            <label v-if="visualizando">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor" class="form-control">
              <option v-for="(professor, index) in professores" :key="index"
               v-bind:value="professor">
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnCancelar" @click="Cancelar()">Cancelar</button>
        <button class="btn btnSalvar" @click="Salvar()">Salvar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_Shared/TituloComponent.vue";
export default {
  name: 'AlunoDetalheComponent',
  components: {
    Titulo,
  },
  data() { 
    return {
      aluno: [],
      professores: [],
      //.id vem do router
      idAluno: this.$route.params.id,
      visualizando: true
    };
  },
  methods: {
    EditarFormulario() {
      this.visualizando = !this.visualizando
    },
    Cancelar() {
      this.visualizando = !this.visualizando
    },
    Salvar() {
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.DataNascimento,
        professor: this.aluno.professor
      };

      this.$http.put(`http://localhost:3000/alunos/${_alunoEditar.id}`, _alunoEditar)
      this.visualizando = !this.visualizando
    }
  },
  created() {
    this.$http
      .get("http://localhost:3000/alunos/" + this.idAluno)
      .then((response) => response.json())
      .then((aluno) => (this.aluno = aluno));

    this.$http.get('http://localhost:3000/professores')
              .then(response => response.json())
              .then(professores => this.professores = professores)
  },
};

</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
  margin-top: 10px;
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
  margin-top: 10px;
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
  margin-top: 10px;
}

.colPequeno {
  width: 20%;
}

input, select {
  margin: 0px;
  padding: 5px 10px;
  border-radius: 5px 1px silver;
  background-color: rgb(245, 245, 245);
  font-family: Montserrat;
  font-size: 1em;
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}
</style>
