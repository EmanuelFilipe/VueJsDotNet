using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data;

public class Repository<T> : IRepository<T> where T : class
{
    public DataContext _context { get; }
    public Repository(DataContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() > 0);
    }

    #region  ALUNOS
    public async Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor = false)
    {
        IQueryable<Aluno> query = _context.Alunos;

        if (includeProfessor) query = query.Include(p => p.Professor);

        query = query.AsNoTracking().OrderBy(a => a.Id);

        return await query.ToListAsync();
    }

    public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor)
    {
        var aluno = _context.Alunos.Where(a => a.Id == alunoId);

        if (includeProfessor) aluno = aluno.Include(p => p.Professor);

        aluno = aluno.AsNoTracking();

        return await aluno.FirstOrDefaultAsync();
    }

    public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor)
    {
         IQueryable<Aluno> query = _context.Alunos;

        if (includeProfessor) query = query.Include(p => p.Professor);

        query = query.AsNoTracking().Where(a => a.ProfessorId == professorId);

        return await query.ToArrayAsync();
    }
    #endregion

    #region PROFESSORES
    public async Task<List<Professor>> GetAllProfessoresAsync(bool includeAluno = false)
    {
        IQueryable<Professor> query = _context.Professores;

        if (includeAluno) 
            query = query.Include(p => p.Alunos);

        query = query.AsNoTracking().OrderBy(p => p.Id);

        return await query.ToListAsync();
    }

    public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno)
    {
        var professor = _context.Professores.Where(a => a.Id == professorId);

        if (includeAluno) professor = professor.Include(p => p.Alunos);

        professor = professor.AsNoTracking();

        return await professor.FirstOrDefaultAsync();
    }
    #endregion
}
