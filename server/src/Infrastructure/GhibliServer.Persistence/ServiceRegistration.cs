using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Domain.Entities;
using GhibliServer.Persistence.DAL;
using GhibliServer.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence
{
    public static class ServiceRegistration
    {
        public static void PersistenceServiceRegister(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserMovieRepository, UserMovieRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketOrderRepository, TicketOrderRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        }
    }
}
