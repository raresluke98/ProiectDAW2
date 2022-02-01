using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProiectDAW2.Authorization;
using ProiectDAW2.Helpers;
using ProiectDAW2.Models;
using ProiectDAW2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProiectDAW2.Services.UserService;
using ProiectDAW2.Entities;
using System.Text.Json.Serialization;

namespace ProiectDAW2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<DataContext>();
            services.AddDbContext<BicycleDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"))
            );
            services.AddCors();
            services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
       

            // Configure Services

            services.AddTransient<BicycleService>();
            services.AddTransient<CompetitionService>();
            services.AddTransient<ServiceService>();
            services.AddTransient<DescriptionService>();


            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, BicycleDbContext context)
        {
            // createTestUsers(context);

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
            

        }
        
        private void createTestUsers(BicycleDbContext context)
        {
            // add hardcoded test users on DB startup
            var testUsers = new List<User>
            { 
                new User { FirstName = "Admin", LastName = "User", Username = "admin", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin},
                new User { FirstName = "Normal", LastName = "User", Username = "user", PasswordHash = BCryptNet.HashPassword("user"), Role = Role.User}
            };
            context.Users.AddRange(testUsers);
            context.SaveChanges();
        }
        
    }
}
