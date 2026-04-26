using AgendaPessoal.Domain;
using AgendaPessoal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPessoal.Controllers
{
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

        // 🔹 POST: /Person/Create
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

    }
}
