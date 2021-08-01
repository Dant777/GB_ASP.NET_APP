using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;

namespace DataLayer.Repository.DAL
{
    public class PersonRepository:IPersonRepository
    {
        private readonly ApplicationDataContext _db;
        public PersonRepository(ApplicationDataContext db)
        {
            _db = db;
        }
        public int Create(Person item)
        {
            _db.Add(item);
            _db.SaveChanges();
            var person = _db.Persons.ToList()[^1];
            return person.Id;
        }
        public IList<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _db.Persons.FirstOrDefault(p => p.Id == id);
        }
        public Person GetByName(string name)
        {
            return _db.Persons.FirstOrDefault(p => p.FirstName.Contains(name));
        }

        public IList<Person> GetCollection(int skip, int take)
        {
            var personSkipArr = _db.Persons.Skip(skip);
            return personSkipArr.Take(take).ToList();
        }

        public void Update(Person item)
        {
            if (!_db.Persons.Any(p => p.Id == item.Id))
            {
                throw new Exception("ID not found");
            }
            _db.Persons.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = _db.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return;
            }
            _db.Persons.Remove(person);
            _db.SaveChanges();
        }
    }
}
