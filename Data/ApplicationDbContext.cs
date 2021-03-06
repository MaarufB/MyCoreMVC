using Microsoft.EntityFrameworkCore;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MyCoreMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}

        public DbSet<Category> Category{ get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<TodoModel> TodoList { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
