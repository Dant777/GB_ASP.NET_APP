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
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            _repository.Create(new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Company = request.Company,
                Age = request.Age
            });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var persons = _repository.GetAll();

            return Ok(persons);
        }
        [HttpGet("person/{personId}")]
        public IActionResult GetAll([FromRoute] int personId)
        {
            var persons = _repository.GetById(personId);

            return Ok(persons);
        }
    }
}
