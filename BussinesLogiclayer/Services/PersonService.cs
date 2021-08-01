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
        public async Task<int> Create(Person item)
        {
            return await _repository.Create(item);
             
        }

        public async Task<IList<Person>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Person> GetById(int id)
        {
            
            return await _repository.GetById(id);
        }

        public async Task<Person> GetByName(string name)
        {

            return await _repository.GetByName(name);
        }

        public async Task<IList<Person>> GetCollection(int skip, int take)
        {

            return await _repository.GetCollection(skip, take);
        }

        public async Task<int> Update(Person item)
        {
            return await _repository.Update(item);
        }

        public async Task<int> Delete(int id)
        {
           return await _repository.Delete(id);
        }
    }
}
