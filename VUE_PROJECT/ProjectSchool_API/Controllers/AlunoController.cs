using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : Controller
{
    public AlunoController()
    {
        
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(new {
                id = 1
            });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou!");
        }
    }

    [HttpGet("{alunoId:int}")]
    public IActionResult Get(int alunoId)
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

    [HttpPut("{alunoId:int}")]
    public IActionResult Put(int alunoId)
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

    [HttpDelete("{alunoId:int}")]
    public IActionResult Delete(int alunoId)
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