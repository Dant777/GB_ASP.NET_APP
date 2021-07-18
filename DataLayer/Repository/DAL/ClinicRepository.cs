using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using DataLayer.Repository.Interfaces;

namespace DataLayer.Repository.DAL
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDataContext _db;
        public ClinicRepository(ApplicationDataContext db)
        {
            _db = db;
        }
        public void Create(Clinic item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }
        public IList<Clinic> GetAll()
        {
            return _db.Clinics.ToList();
        }

        public Clinic GetById(int id)
        {
            return _db.Clinics.FirstOrDefault(p => p.Id == id);
        }
        public Clinic GetByName(string name)
        {
            return _db.Clinics.FirstOrDefault(p => p.Name.Contains(name));
        }

        public IList<Clinic> GetCollection(int id, int count)
        {
            return _db.Clinics.Where(p => p.Id >= id && p.Id <= id + count).ToList();
        }

        public void Update(Clinic item)
        {
            if (!_db.Clinics.Any(p => p.Id == item.Id))
            {
                throw new Exception("ID not found");
            }
            _db.Clinics.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var clinic = _db.Clinics.FirstOrDefault(p => p.Id == id);
            if (clinic == null)
            {
                return;
            }
            _db.Clinics.Remove(clinic);
            _db.SaveChanges();
        }
    }
}
