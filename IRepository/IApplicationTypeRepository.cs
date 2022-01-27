using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.IRepository
{
    public interface IApplicationTypeRepository
    {
        Task <IEnumerable<ApplicationType>> GetAllAsync();
        Task AddAsync(ApplicationType obj);
        Task SaveChangesAsync();
        Task Update(ApplicationType obj);
        Task DeleteAsync(ApplicationType obj);
        Task<ApplicationType> FindAsync(int? id);
    }
}
