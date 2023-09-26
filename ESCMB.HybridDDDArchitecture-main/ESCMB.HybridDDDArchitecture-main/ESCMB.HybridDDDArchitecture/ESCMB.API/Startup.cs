using AutoMapper;
using Common.Application.Adapters.EventBus;
using ESCMB.API.Filters;
using ESCMB.Application.Common;
using ESCMB.Application.Registrations;
using ESCMB.Infraestructure.Registrations;
using Microsoft.OpenApi.Models;

namespace ESCMB.API
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApplicationDependencies();
            services.AddInfraestructureDependencies(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESCMB Hybrid Architecture Project", Version = "v1" });
            });
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add<BaseExceptionFilter>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            CustomMapper.MapperInstance = app.ApplicationServices.GetRequiredService<IMapper>();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(DefineSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            UseEventBus(app);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        private void UseEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        }
    }
}
