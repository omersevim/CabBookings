using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
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
using OmerCemSevim.CabsBooking.ApplicationCore.RepositoryInterfaces;
using OmerCemSevim.CabsBooking.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OmerCemSevim.CabsBooking.API", Version = "v1" });
            });

            services.AddDbContext<CabsBookingDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CabsBookingDbConnection"));
            });

            services.AddScoped<ICabRepository, CabRepository>();
            services.AddScoped<ICabService, CabService>();
            services.AddScoped<IPlacesRepository, PlacesRepository>();
            services.AddScoped<IPlacesService, PlacesService>();
            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IBookingsService, BookingsService>();
            services.AddScoped<IBookingsHistoryRepository, BookingsHistoryRepository>();
            services.AddScoped<IBookingsHistoryService, BookingsHistoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OmerCemSevim.CabsBooking.API v1"));
            }
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("angularSPAClientUrl")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
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
