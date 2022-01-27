using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.IRepository
{
    public interface ICategoryRepository
    {
        Task <IEnumerable<Category>> GetAllAsync();
        Task GetSingleAsync(int? id);
        Task AddAsync(Category obj);
        //Task UpdateAsync(int id);
        //Task DeleteAsync(int id);
    }
}
