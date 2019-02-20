using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;

namespace AwesomeApi.Controllers
{
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }
        [FunctionName(nameof(GetAll))]
        public IActionResult GetAll([HttpTrigger("get", Route = "people")]HttpRequest request)
        {
            return Ok(peopleRepository.GetAll());
        }

        [FunctionName(nameof(Get))]
        public IActionResult Get([HttpTrigger("get", Route = "people/{id}")]HttpRequest request, int id)
        {
            var person = peopleRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
