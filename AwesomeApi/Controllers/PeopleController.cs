using Microsoft.AspNetCore.Mvc;

namespace AwesomeApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(peopleRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
