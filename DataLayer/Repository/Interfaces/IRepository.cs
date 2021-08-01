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
        int Create(T item);
        IList<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        IList<T> GetCollection(int skip, int take);
        void Update(T item);
        void Delete(int id);
    }
}
