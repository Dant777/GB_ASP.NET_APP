using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogiclayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;

namespace BussinesLogiclayer.Services
{
    
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }
        public int Create(Person item)
        {
            int id = _repository.Create(item);
            return id;
        }

        public IList<Person> GetAll()
        {
            var persons = _repository.GetAll();
            return persons;
        }

        public Person GetById(int id)
        {
            var person = _repository.GetById(id);

            return person;
        }

        public Person GetByName(string name)
        {
            var person = _repository.GetByName(name);

            return person;
        }

        public IList<Person> GetCollection(int skip, int take)
        {
            var persons = _repository.GetCollection(skip, take);

            return persons;
        }

        public void Update(Person item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
