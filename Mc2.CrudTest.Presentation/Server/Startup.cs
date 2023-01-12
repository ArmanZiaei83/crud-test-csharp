using Autofac;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Interfaces.Repositories;
using Mc2.CrudTest.Application.Interfaces.Services;
using Mc2.CrudTest.Persistence.Contexts;
using Mc2.CrudTest.Persistence.Repositories.Customers;
using Mc2.CrudTest.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        private readonly string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = configuration.GetConnectionString("dbConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Mc2.Crud", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder container)
        {
            container.RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            container.RegisterType<EFDataContext>()
                .WithParameter("connectionString", _connectionString)
                .AsSelf()
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(typeof(EFCustomerRepository).Assembly)
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(typeof(CustomerAppService).Assembly)
                .AssignableTo<IService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mc2.Crud v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}