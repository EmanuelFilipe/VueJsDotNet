using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : Controller
{
    public ProfessorController()
    {

    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpGet("{professorId:int}")]
    public IActionResult Get(int professorId)
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPost]
    public IActionResult Post()
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpPut("{professorId:int}")]
    public IActionResult Put(int professorId)
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpDelete("{professorId:int}")]
    public IActionResult Delete(int professorId)
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }
}
