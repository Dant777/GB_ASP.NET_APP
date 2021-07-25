using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.DAL
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDataContext _db;
        public HospitalRepository(ApplicationDataContext db)
        {
            _db = db;
        }
        public void Create(Hospital item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
        public IList<Hospital> GetAll()
        {
            return _db.Hospitals
                .Include(x => x.Persons)
                .AsNoTracking()
                .ToList();

        }

        public Hospital GetById(int id)
        {
            return _db.Hospitals
                .Include(x => x.Persons)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
        public Hospital GetByName(string name)
        {
            return _db.Hospitals
                .Include(x => x.Persons)
                .AsNoTracking()
                .FirstOrDefault(p => p.Name.Contains(name));
        }

        public IList<Hospital> GetCollection(int id, int count)
        {
            return _db.Hospitals
                .Include(x => x.Persons)
                .AsNoTracking()
                .Where(p => p.Id >= id && p.Id <= id + count).ToList();
        }

        public void Update(Hospital item)
        {
            if (!_db.Hospitals.Any(p => p.Id == item.Id))
            {
                throw new Exception("ID not found");
            }
            _db.Hospitals.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var hospital = _db.Hospitals.FirstOrDefault(p => p.Id == id);
            if (hospital == null)
            {
                return;
            }
            _db.Hospitals.Remove(hospital);
            _db.SaveChanges();
        }
        public void AddHospitalOrPerson(int personId, int hospitalId)
        {
            var person = _db.Persons.Find(personId);
            var hospital = _db.Hospitals.Find(hospitalId);
            person.Hospitals.Add(hospital);
            _db.Persons.Update(person);
            _db.SaveChanges();
        }
    }
}
