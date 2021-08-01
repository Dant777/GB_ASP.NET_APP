using System.Threading.Tasks;
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
        public async Task<IActionResult>  Create([FromBody] PersonRequest request)
        {
            var person = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Company = request.Company,
                Age = request.Age
            };
            int id = await _repository.Create(person);
            return Ok(id);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _repository.GetAll();

            return Ok(persons);
        }
        [HttpGet("person/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var person = await _repository.GetById(id);

            return Ok(person);
        }
        [HttpGet("person")]
        public async Task<IActionResult> GetByName([FromQuery] string searchTerm)
        {
            var person = await _repository.GetByName(searchTerm);

            return Ok(person);
        }
        [HttpGet("persons")]
        public async Task<IActionResult> GetCollection([FromQuery] int skip, [FromQuery] int take)
        {
            var persons = await _repository.GetCollection(skip, take);

            return Ok(persons);
        }

        [HttpPut("persons")]
        public async Task<IActionResult> Update(int id, PersonRequest request)
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
            await _repository.Update(person);

            return Ok();
        }

        [HttpDelete("person/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            await _repository.Delete(id);

            return Ok();
        }
    }
}
