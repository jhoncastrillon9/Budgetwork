using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Badgetwork.Infrastructure.Context;
using Badgetwork.Infrastructure.Entities;
using Badgetwork.Infrastructure.Repository;
using Budgetwork.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;

namespace Budgetwork.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Contexto                  
            services.AddScoped<BadgetworkContext, BadgetworkContext>();
            services.AddDbContext<BadgetworkContext>(options => options.UseSqlServer(Configuration["DataBaseSettings:StringConnection"]));
            //Modelo Acceso a Datos
            services.AddScoped<BaseRepository<Badget>, BaseRepository<Badget>>();
            services.AddScoped<BaseRepository<BadgetItem>, BaseRepository<BadgetItem>>();
            services.AddScoped<BaseRepository<UnitaryPrice>, BaseRepository<UnitaryPrice>>();
            //Servicios
            services.AddScoped<BaseService<Badget>, BaseService<Badget>>();
            services.AddScoped<BaseService<BadgetItem>, BaseService<BadgetItem>>();
            services.AddScoped<BaseService<UnitaryPrice>, BaseService<UnitaryPrice>>();
            //Servicios Fijos de Radzen Blazor
            services.AddRazorPages();
            services.AddScoped<NotificationService, NotificationService>();
            services.AddScoped<DialogService, DialogService>();
            services.AddScoped<NotificationMessage, NotificationMessage>();            
            services.AddServerSideBlazor().AddCircuitOptions(opt => { opt.DetailedErrors = true; });
        }

        // This method gets called by the runtime. Use this metho   d to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
