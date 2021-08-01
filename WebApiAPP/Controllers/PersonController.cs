using BussinesLogiclayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _repository;

        public PersonController(IPersonService repository)
        {
            _repository = repository;
        }

        [HttpPost()]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            var person = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Company = request.Company,
                Age = request.Age
            };
            int id = _repository.Create(person);
            return Ok(id);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var persons = _repository.GetAll();

            return Ok(persons);
        }
        [HttpGet("person/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var person = _repository.GetById(id);

            return Ok(person);
        }
        [HttpGet("person")]
        public IActionResult GetByName([FromQuery] string searchTerm)
        {
            var person = _repository.GetByName(searchTerm);

            return Ok(person);
        }
        [HttpGet("persons")]
        public IActionResult GetCollection([FromQuery] int skip, [FromQuery] int take)
        {
            var persons = _repository.GetCollection(skip, take);

            return Ok(persons);
        }

        [HttpPut("persons")]
        public IActionResult Update(int id, PersonRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }   
            Person person = new Person()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Company = request.Company,
                Age = request.Age
            };
            _repository.Update(person);

            return Ok();
        }

        [HttpDelete("person/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _repository.Delete(id);

            return Ok();
        }
    }
}
