using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    public IRepository<Aluno> _repo { get; }

    public AlunoController(IRepository<Aluno> repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllAlunosAsync(true);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpGet("{alunoId:int}")]
    public async Task<IActionResult> GetAlunoById(int alunoId)
    {
        try
        {
            var result = await _repo.GetAlunoAsyncById(alunoId, true);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpGet("ByProfessor/{professorId:int}")]
    public async Task<IActionResult> GetByProfessorId(int professorId)
    {
        try
        {
            var result = await _repo.GetAlunosAsyncByProfessorId(professorId, true);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Aluno model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
                return Created($"/api/aluno/{model.Id}", model);

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPut("{alunoId:int}")]
    public async Task<IActionResult> Put(int alunoId, Aluno model)
    {
        try
        {
            var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

            if (aluno == null) return NotFound();

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                aluno = await _repo.GetAlunoAsyncById(alunoId, true);
                return Created($"/api/aluno/{model.Id}", aluno);
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpDelete("{alunoId:int}")]
    public async Task<IActionResult> Delete(int alunoId)
    {
        try
        {
            var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

            if (aluno == null) return NotFound();

            _repo.Delete(aluno);

            if (await _repo.SaveChangesAsync()) return Ok();

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }
}