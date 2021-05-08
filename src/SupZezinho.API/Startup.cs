using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using OData.Swagger.Services;
using SupZezinho.Application;
using SupZezinho.Application.contratos;
using SupZezinho.Domain.models;
using SupZezinho.Repository;

namespace SupZezinho.API
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
            services.AddDbContext<SupZezinhoContext>(
               context => context.UseSqlite(Configuration.GetConnectionString("conSupZezinho"))
            );
            services.AddOData();
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore
                     );
            services.AddScoped<IProdutoServices, ProdutoService>();
            services.AddScoped<IFornecedorServices, FornecedorService>();
            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<IFornecedoresRepositry, FornecedoresRrepository>();
            services.AddScoped<IProdutosRepositry, ProdutosRrepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SupZezinho.API", Version = "v1" });
            });
            services.AddOdataSwaggerSupport();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupZezinho.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
            });
        }
    }
}
