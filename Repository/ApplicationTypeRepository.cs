using Microsoft.EntityFrameworkCore;
using MyCoreMVC.Data;
using MyCoreMVC.IRepository;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Repository
{
    public class ApplicationTypeRepository: IApplicationTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ApplicationType>> GetAllAsync()
        {
            var applicationTypeObj = await _context.ApplicationType.ToListAsync();

            return applicationTypeObj;
        }

        public async Task AddAsync(ApplicationType obj)
        {
            await _context.ApplicationType.AddAsync(obj);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(ApplicationType obj)
        {
            _context.ApplicationType.Update(obj);
        }
    }
}
