using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using DataLayer.Request;
using Microsoft.Extensions.Logging;

namespace WebApiAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _repository;

        public ClinicController(IClinicRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Clinic request)
        {
            _repository.Create(new Clinic()
            {
                Name = request.Name,
                Persons = request.Persons
            });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var persons = _repository.GetAll();

            return Ok(persons);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var person = _repository.GetById(id);

            return Ok(person);
        }
        [HttpGet()]
        public IActionResult GetByName([FromQuery] string searchTerm)
        {
            var clinic = _repository.GetByName(searchTerm);

            return Ok(clinic);
        }
        [HttpGet()]
        public IActionResult GetCollection([FromQuery] int skip, [FromQuery] int take)
        {
            var clinics = _repository.GetCollection(skip, take);

            return Ok(clinics);
        }

        [HttpPut()]
        public IActionResult Update(int id, ClinicRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }   
            Clinic clinic = new Clinic()
            {
               Name = request.Name,
               Persons = request.Persons
            };
            _repository.Update(clinic);

            return Ok();
        }

        [HttpDelete("{id}")]
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
