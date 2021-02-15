using AutoMapper;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.Services;
using Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService;
using Hahn.ApplicatonProcess.December2020.Domain.Validation;
using Hahn.ApplicatonProcess.December2020.Web.Filters;
using Hahn.ApplicatonProcess.December2020.Web.Helpers;
using Hahn.ApplicatonProcess.December2020.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HahnApplicatonProcess.December2020.Test
{
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
            // services.AddAutoMapper(Assembly.Load("Hahn.ApplicatonProcess.December2020.Web"));
            // services.AddTransient<IMapper, Mapper>();
            // Auto Mapper Configurations
            services.AddAutoMapper(c => c.AddProfile(typeof(AutoMapperProfiles)));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddControllers().AddApplicationPart(Assembly.Load("Hahn.ApplicatonProcess.December2020.Web")).AddControllersAsServices();
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "ApplicantDb"));

         
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
