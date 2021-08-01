using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogiclayer.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<int> Create(T item);
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<IList<T>> GetCollection(int skip, int take);
        Task<int> Update(T item);
        Task<int> Delete(int id);
    }
}
