using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProyectoIntegradorApi.Data;
// Usings Nuevos
//using ProyectoIntegradorApi.DAL.Tickets;
//using ProyectoIntegradorApi.DAL.Repositorios;

using ProyectoIntegradorApi.Tickets;
using ProyectoIntegradorApi.Repositorios;


namespace ProyectoIntegradorApi
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
            // Inyeccion de Dependencias
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL")));
            // Inyeccion de Dependencias Singleton
            services.AddSingleton<ITicketRepositorio>(new TicketDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddSingleton<ITicketResolutorRepositorio>(new TicketResolutorDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddSingleton<IUsuario_EmpresaRepositorio>(new Usuario_EmpresaDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddSingleton<IUsuario_PerfilRepositorio>(new Usuario_PerfilDAL(Configuration.GetConnectionString("CadenaSQL")));
            // Consultas
            services.AddSingleton<ITicketsPorEmpresaRepositorio>(new TicketsPorEmpresaDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddSingleton<ITicketsPorSistemaRepositorio>(new TicketsPorSistemaDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddSingleton<ITicketsPorModuloRepositorio>(new TicketsPorModuloDAL(Configuration.GetConnectionString("CadenaSQL")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoIntegradorApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoIntegradorApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
