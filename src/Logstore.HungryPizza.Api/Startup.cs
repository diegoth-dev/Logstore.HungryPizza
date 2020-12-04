using System;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Logstore.HungryPizza.Application;
using Logstore.HungryPizza.Application.Clientes;
using Logstore.HungryPizza.Application.Interfaces;
using Logstore.HungryPizza.Application.Pedidos;
using Logstore.HungryPizza.Core.Interfaces;
using Logstore.HungryPizza.Core.SeedWork;
using Logstore.HungryPizza.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Logstore.HungryPizza.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();

            services.AddControllers().AddFluentValidation();
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hungry Pizza API",
                    Description = "",
                    Contact = new OpenApiContact { Name = "Diego Thomazi", Email = "diegothomazi@hotmail.com", Url = new Uri("https://www.linkedin.com/in/diego-thomazi-325b8b35") }
                });
            });

            services.AddScoped<IPedidoAppService, PedidoAppService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
