using AutoMapper;
using Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles;
using Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl;
using Avanade.BestPractices.Infrasctructure.CrossCutting.Middlewares.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Avanade.BestPractices.API
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
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<AccountProfile>();
                x.AddProfile<ChargeProfile>();
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddEntityDependency(Configuration);
            services.AddIdentityUserLogged();
            services.AddRepositoryDependencies();
            services.AddServiceDependencies();
            services.AddInfrastructureDependencies();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Avanade.BestPractices.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avanade.BestPractices.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.IdentityUserLogged();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
