using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IList<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public void Create(Person item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
    }
}
