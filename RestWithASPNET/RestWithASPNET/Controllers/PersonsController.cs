using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Models;
using RestWithASPNET.Services.Implementation;

namespace RestWithASPNET.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }


        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }
        
        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody]Person person)
        {
            if (person == null) return BadRequest();
            var p = _personService.Update(person);
            if (p == null) return NoContent();
            return new ObjectResult(p);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
