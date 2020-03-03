using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestBook.Api.Calculator;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.Api.Service;
using RestBook.App.Calculator;
using RestBook.App.Provider;
using RestBook.App.Service;
using RestBook.Background;
using RestBook.Data.EF;
using RestBook.Data.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace RestBook
{

    

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        private class DataConfig : IDataConfig
        {
            public bool IsLogToConsole { get; set; }

            public string Connection { get; set; }
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IDataConfig>(x => new DataConfig {Connection= Configuration.GetConnectionString("db"),IsLogToConsole = false });
            services.AddScoped<IDataRepositoryProvider, EFRepositoryProvider>();
            services.AddScoped<ICatalogProvider, CatalogProvider>();
            services.AddScoped<IOrgProvider, OrgProvider>();
            services.AddScoped<IAccessTokenService, AccessTokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IUserAdminService, UserAdminService>();
            services.AddScoped<IOrderProcessingService, OrderProcessingService>();
            services.AddScoped<IOrderCalculator, OrderCalculator>();
            services.AddScoped<IOrderProvider, OrderProvider>();
            services.AddScoped<IBookingService, BookingService>();


            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrgRepository, OrgRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddHostedService<SessionService>();
            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestBook API", Version = "v1" });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestBook API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
