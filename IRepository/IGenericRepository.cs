using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCoreMVC.IRepository
{
    interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync();
        Task Update();
        Task AddAsync();
        Task DeleteAsync();
        Task SaveAsync();

    }
}
