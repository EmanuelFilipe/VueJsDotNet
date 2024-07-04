using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : Controller
{
    public IRepository<Professor> _repo { get; }

    public ProfessorController(IRepository<Professor> repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllProfessoresAsync(true);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpGet("{professorId:int}")]
    public async Task<IActionResult> GetProfessorById(int professorId)
    {
        try
        {
            var result = await _repo.GetProfessorAsyncById(professorId, true);
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Professor model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
                return Created($"/api/professor/{model.Id}", model);

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPut("{professorId:int}")]
    public async Task<IActionResult> Put(int professorId, Professor model)
    {
        try
        {

            var professor = await _repo.GetProfessorAsyncById(professorId, false);

            if (professor == null) return NotFound();

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                professor = await _repo.GetProfessorAsyncById(professorId, true);
                return Created($"/api/professor/{model.Id}", professor);
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpDelete("{professorId:int}")]
    public async Task<IActionResult> Delete(int professorId)
    {
        try
        {
            var professor = await _repo.GetProfessorAsyncById(professorId, false);

            if (professor == null) return NotFound();

            _repo.Delete(professor);

            if (await _repo.SaveChangesAsync()) return Ok();

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }
}
