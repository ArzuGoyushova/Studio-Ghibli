using FluentValidation.AspNetCore;
using GhibliServer.Application.Dtos.About;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Dtos.Blog;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Dtos.Movie;
using GhibliServer.Application.Dtos.Role;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application
{
    public static class ServiceRegistration
    {
        public static void ApplicationServiceRegister(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            services.AddControllers().AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblyContaining<LoginDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<AboutCreateOrUpdateDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<BlogCreateOrUpdateDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<CategoryCreateOrUpdateDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<EventCreateOrUpdateDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<MovieCreateOrUpdateDtoValidator>();
                option.RegisterValidatorsFromAssemblyContaining<RoleCreateDtoValidator>();
            });
        }
    }
}
