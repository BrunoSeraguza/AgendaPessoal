using AgendaPessoal.Service;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPessoal.Controlers
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
    }
}
