using AgendaPessoal.Domain;
using AgendaPessoal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPessoal.Controllers;

public class PersonController : Controller
{
    private readonly PersonService _service;

    public PersonController(PersonService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetAll()
    {
        var people = await _service.GetAll();
        return Json(people);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Person person)
    {
        try
        {
            await _service.Create(person);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Mensagem: {ex.Message} | Stack trace: {ex.StackTrace}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Person person)
    {
        try
        {
            await _service.Update(person);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
