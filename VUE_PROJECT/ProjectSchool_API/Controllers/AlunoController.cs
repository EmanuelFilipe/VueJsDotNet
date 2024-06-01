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
        return View();
    }

    [HttpGet("{professorId:int}")]
    public IActionResult Get(int professorId)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return View();
    }

    [HttpPut("{professorId:int}")]
    public IActionResult Put(int professorId)
    {
        return View();
    }

    [HttpDelete("{professorId:int}")]
    public IActionResult Delete(int professorId)
    {
        return View();
    }
}