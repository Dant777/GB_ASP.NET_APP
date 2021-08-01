using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.DAL
{
    public class PersonRepository:IPersonRepository
    {
        private readonly ApplicationDataContext _db;
        public PersonRepository(ApplicationDataContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Person item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            var person = await _db.Persons.ToListAsync();
            return person[^1].Id;
        }
        public async Task<IList<Person>> GetAll()
        {
            return await _db.Persons.ToArrayAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _db.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Person> GetByName(string name)
        {
            return await _db.Persons.FirstOrDefaultAsync(p => p.FirstName.Contains(name));
        }

        public async Task<IList<Person>>GetCollection(int skip, int take)
        {
            
            return await _db.Persons
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> Update(Person item)
        {
            if (!await _db.Persons.AnyAsync(p => p.Id == item.Id))
            {
                throw new Exception("ID not found");
            }
            _db.Persons.Update(item);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var person = await _db.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                throw new Exception("ID not found");
            }
            _db.Persons.Remove(person);
            return await _db.SaveChangesAsync();
        }
    }
}
