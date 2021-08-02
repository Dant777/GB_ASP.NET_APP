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
using DataLayer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using PersonResponse = DataLayer.Response.PersonResponse;

namespace WebApiAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _repository;

        public HospitalController(IHospitalRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HospitalRequest request)
        {
            _repository.Create(new Hospital(request.Name));
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var hospitals = _repository.GetAll();
            List<HospitalResponse> personResponses = new List<HospitalResponse>();
            foreach (var hospital in hospitals)
            {
                personResponses.Add(new HospitalResponse()
                {
                    Name = hospital.Name
                });
            }
            return Ok(personResponses);
        }
        [HttpGet("hospital/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var hospital = _repository.GetById(id);
            HospitalResponse hospitalResponse = new HospitalResponse()
            {
                Name = hospital.Name
            };
            return Ok(hospitalResponse);
        }
        [HttpGet("hospital")]
        public IActionResult GetByName([FromQuery] string searchName)
        {
            var hospital = _repository.GetByName(searchName);
            HospitalResponse hospitalResponse = new HospitalResponse()
            {
                Name = hospital.Name
            };
            return Ok(hospitalResponse);
        }

        [HttpGet("hospitals")]
        public IActionResult GetCollection([FromQuery] int skip, [FromQuery] int take)
        {
            var hospitals = _repository.GetCollection(skip, take);
            List<HospitalResponse> personResponses = new List<HospitalResponse>();
            foreach (var hospital in hospitals)
            {
                personResponses.Add(new HospitalResponse()
                {
                    Name = hospital.Name
                });
            }
            return Ok(personResponses);
        }

        [HttpGet("persons")]
        public IActionResult GetHospitals(int hospitalId)
        {
            var hosp = _repository.GetById(hospitalId);

            List<PersonResponse> personResponses = new List<PersonResponse>();
            foreach (var person in hosp.Persons)
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

        [HttpPut("hospital")]
        public IActionResult Update(int id, HospitalRequest request)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }   
            Hospital hospital = new Hospital(request.Name);
            hospital.Id = id;
            _repository.Update(hospital);

            return Ok();
        }

        [HttpPut("persons/{personId}/hospital/{hospitalId}")]
        public IActionResult AddHospital([FromRoute] int personId, [FromRoute] int hospitalId)
        {
            if (personId == null || personId == 0)
            {
                return NotFound();
            }

            _repository.AddHospitalOrPerson(personId, hospitalId);

            return Ok();
        }

        [HttpDelete("hospital/{id}")]
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
