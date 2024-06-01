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
        return View();
    }

    [HttpGet("{alunoId:int}")]
    public IActionResult Get(int alunoId)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return View();
    }

    [HttpPut("{alunoId:int}")]
    public IActionResult Put(int alunoId)
    {
        return View();
    }

    [HttpDelete("{alunoId:int}")]
    public IActionResult Delete(int alunoId)
    {
        return View();
    }
}
