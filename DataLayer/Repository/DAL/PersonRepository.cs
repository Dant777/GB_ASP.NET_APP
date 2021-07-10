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
        public void Create(Person item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
        public IList<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _db.Persons.FirstOrDefault(p => p.Id == id);
        }
    }
}
