using MyCoreMVC.Data;
using MyCoreMVC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ApplicationTypeRepository = new ApplicationTypeRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public IApplicationTypeRepository ApplicationTypeRepository { get; private set; }//=> new ApplicationTypeRepository(_context);
        public ICategoryRepository CategoryRepository { get; private set; }//=> new CategoryRepository(_context);
    
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
