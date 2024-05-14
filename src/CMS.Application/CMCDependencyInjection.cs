using CMS.Application.UseCases.Auth;
using CMS.Application.UseCases.EmailService;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application
{
    public static class CMCDependencyInjection
    {
        public static IServiceCollection AddCMSApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthServise, AuthServise>();
            services.AddScoped<IEmailService, EmailServise>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}