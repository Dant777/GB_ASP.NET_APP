using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Validation.Interfaces;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using DataLayer.Request;
using DataLayer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace WebApiAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonBusinessLogicService _personService;

        public PersonController(IPersonRepository repository, IPersonBusinessLogicService personService)
        {
            _repository = repository;
            _personService = personService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] PersonRequest request)
        {
            Person person = new Person(request.FirstName,
                request.LastName,
                request.Email, 
                request.Company,
                request.Age);
           
            IOperationResult<Person> result = _personService.Create(person);
            if (!result.Succeed)
            {
                return Ok(result.Failures);
            }
            _repository.Create(result.Result);
            return Ok(result.Result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var persons = _repository.GetAll();
            List<PersonResponse> personResponses = new List<PersonResponse>();
            foreach (var person in persons)
            {
                personResponses.Add(new PersonResponse()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Company = person.Company,
                    Age = person.Age
                });
            }
            return Ok(personResponses);
        }
        [HttpGet("person/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var person = _repository.GetById(id);
            PersonResponse personRespons = new PersonResponse()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Company = person.Company,
                Age = person.Age
            };

            return Ok(personRespons);
        }
        [HttpGet("person")]
        public IActionResult GetByName([FromQuery] string searchName)
        {
            var person = _repository.GetByName(searchName);

            PersonResponse personRespons = new PersonResponse()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Company = person.Company,
                Age = person.Age
            };

            return Ok(personRespons);
        }
        [HttpGet("persons")]
        public IActionResult GetCollection([FromQuery] int skip, [FromQuery] int take)
        {
            var persons = _repository.GetCollection(skip, take);

            List<PersonResponse> personResponses = new List<PersonResponse>();
            foreach (var person in persons)
            {
                personResponses.Add(new PersonResponse()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Company = person.Company,
                    Age = person.Age
                });
            }
            return Ok(personResponses);
        }

        [HttpGet("hospitals")]
        public IActionResult GetHospitals( int personId)
        {
            var person = _repository.GetById(personId);
            List<HospitalResponse> hospitalResponses = new List<HospitalResponse>();
            foreach (var hospital in person.Hospitals)
            {
                hospitalResponses.Add(new HospitalResponse()
                {
                    Name = hospital.Name
                });
            }
            return Ok(hospitalResponses);
        }

        [HttpPut("persons")]
        public IActionResult Update(int id, PersonRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Person person = new Person(request.FirstName,
                request.LastName,
                request.Email,
                request.Company,
                request.Age);
            person.Id = id;
            _repository.Update(person);

            return Ok();
        }

        [HttpPut("persons/{personId}/hospital/{hospitalId}")]
        public IActionResult AddHospital([FromRoute] int personId, [FromRoute] int hospitalId)
        {
            if ( personId == 0)
            {
                return NotFound();
            }

            _repository.AddHospitalOrPerson(personId, hospitalId);

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
