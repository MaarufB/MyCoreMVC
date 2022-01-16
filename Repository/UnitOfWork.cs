using MyCoreMVC.Data;
using MyCoreMVC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IApplicationTypeRepository ApplicationTypeRepository => new ApplicationTypeRepository(_context); 
    }
}
