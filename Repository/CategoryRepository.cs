using MyCoreMVC.Data;
using MyCoreMVC.IRepository;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddSync(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task ICategoryRepository.AddAsync(Category obj)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> ICategoryRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task ICategoryRepository.GetSingleAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
