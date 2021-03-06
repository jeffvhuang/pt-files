using PTFiles.Application;
using PTFiles.Infrastructure;
using PTFiles.Persistence;
using PTFiles.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using PTFiles.Application.Common.Interfaces.Persistence;

namespace PTFiles.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string CorsAllowOrigins = "_corsAllowOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();
            services.AddPersistence(Configuration);

            var origins = Configuration["AllowedOrigins"].Split(";");

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsAllowOrigins,
                    builder =>
                    {
                        builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithOrigins(origins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllers()
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IPTFilesDbContext>())
                 .AddNewtonsoftJson();

            services.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "PTFiles API";
                    document.Info.Description = "REST API for PTFiles.";
                };
            });
        }

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

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseCors(CorsAllowOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
