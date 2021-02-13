using AutoMapper;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService;
using Hahn.ApplicatonProcess.December2020.Domain.Validation;
using Hahn.ApplicatonProcess.December2020.Web.Filters;
using Hahn.ApplicatonProcess.December2020.Web.Middleware;
using Hahn.ApplicatonProcess.December2020.Web.Middlware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Domain.Services;
using Hahn.ApplicatonProcess.December2020.Domain.Infrastructure;
using Swashbuckle.Examples;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Contracts.V1.Requests;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt =>
            {
                opt.Filters.Add(new ValidateResultFilter());
              

            }).AddFluentValidation(fvc =>
            {
                fvc.RegisterValidatorsFromAssemblyContaining<ApplicantRequestValidator>();
                
            });

            // Loggin and centralized error handling in .net 5
            services.AddAutoMapper(typeof(Startup));
          
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "ApplicantDb"));

            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddTransient<IValidator<ApplicantRequest>, ApplicantRequestValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Applicant Tracking",
                    Version = "v1",
                    Description = "A simple Applicant tracking system",

                });
                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        context.Response.ContentType = "application/json";
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        var result = context.Get(error.Error);
                        await context.Response.WriteAsync(result);
                    });
            });

            //  app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseSerilogRequestLogging();

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Applicant Tracker");
                c.RoutePrefix = "swagger";
            });

            app.UseRouting();

            // app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Home");
            });
       
        }
    }
}
