using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data;

public interface IRepository<T> where T: class
{
    //GERAL
    void Add(T entity);

    void Update(T entity);

    void Delete(T entity); 

    Task<bool> SaveChangesAsync();

    //Alunos
    Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor);
    Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor);
    Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor);

    //Professor
    Task<List<Professor>> GetAllProfessoresAsync(bool includeAluno);
    Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno);
}
