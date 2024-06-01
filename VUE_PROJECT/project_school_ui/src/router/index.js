import Vue from 'vue'
import VueRouter from 'vue-router'
import AlunosComponent from '../components/Aluno/AlunosComponent.vue'
import AlunoDetalheComponent from '../components/Aluno/AlunoDetalheComponent'
import ProfessorComponent from '../components/Professor/ProfessorComponent.vue'
import SobreComponent from '../components/Sobre/Sobre.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/professores',
    name: 'Professores',
    component: ProfessorComponent
  },
  {
    path: '/alunos/:prof_id',
    name: 'Alunos',
    component: AlunosComponent
  },
  {
    path: '/alunosall',
    name: 'Alunos',
    component: AlunosComponent
  },
  {
    path: '/alunoDetalhe/:id',
    name: 'AlunoDetalhe',
    component: AlunoDetalheComponent
  },
  {
    path: '/sobre',
    name: 'Sobre',
    component: SobreComponent
  }
]

const router = new VueRouter({
  routes
})

export default router
