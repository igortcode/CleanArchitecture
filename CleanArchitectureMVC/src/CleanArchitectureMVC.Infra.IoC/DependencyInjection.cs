using CleanArchitectureMVC.Application.Interfaces;
using CleanArchitectureMVC.Application.Mappings;
using CleanArchitectureMVC.Application.Services;
using CleanArchitectureMVC.Domain.Interfaces;
using CleanArchitectureMVC.Infra.Data.Context;
using CleanArchitectureMVC.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitectureMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchitectureMVC.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
