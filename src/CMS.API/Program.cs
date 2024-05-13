using CMS.Infrastructure;
using CMS.Application;
using CMS.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using CMS.Infrastructure.Persistance;

namespace CMS.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
            builder.Services.AddCMSApplication();
            builder.Services.AddCMSInfrastructure(builder.Configuration);

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false; 
                options.Password.RequireUppercase = false; 
                options.Password.RequiredLength = 6; 
            })
            .AddEntityFrameworkStores<CMSDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("_myAllowSpecificOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Student", "Teacher", "HeadTeacher" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            await app.RunAsync();
        }

    }
}
