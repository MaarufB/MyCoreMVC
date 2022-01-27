using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyCoreMVC.Data;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using MyCoreMVC.Repository;
using MyCoreMVC.IRepository;

namespace MyCoreMVC.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                CloseButton = true,

            });

            services.AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddControllersWithViews();
            //This is for testing
            services.AddRazorPages();

            return services;
        }

    }
}
