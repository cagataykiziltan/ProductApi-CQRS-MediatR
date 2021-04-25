using AutoMapper;
using ProductService.Application.ProductServices.Queries.Response;
using ProductService.Domain.Products;
using ProductService.Infrastructure.DependencyRegistrar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductService.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } 
        public void ConfigureServices(IServiceCollection services)
        {          

            ServiceRegistrar.RegisterCustomServices(services);
            
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hepsi API", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public class MyMappingProfiles : Profile
        {
            public MyMappingProfiles()
            {
                CreateMap<Product, GetProductQueryResponse>();
                CreateMap<Domain.Products.Categories.Category,Category>();
            }
        }

    }
}
