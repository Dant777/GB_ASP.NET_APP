﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        IList<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        IList<T> GetCollection(int id, int count);
        void Update( T item);
        void Delete(int id);
        public void AddHospitalOrPerson(int personId, int hospitalId);
    }
}
