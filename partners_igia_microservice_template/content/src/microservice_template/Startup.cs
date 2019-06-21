using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace microservice_template
{
    public class Startup
    {
        readonly string application_name; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            application_name = "microservice_template";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            Console.WriteLine("\tAddSwaggerGen");
            try
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v2", new Info { Title = application_name, Version = "v2" });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tAddSwaggerGen Error:" + ex.Message);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
			}
			//app.UseHttpsRedirection();
			
            app.UseMvc();

            Console.WriteLine("\tUseSwagger");
            try
            {
                app.UseSwagger(c =>
                {
                    //c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                    c.RouteTemplate = "{documentName}/api-docs";
                });
            }
            catch (Exception ex)
            {                
                Console.WriteLine("\t\tUseSwagger Error:" + ex.Message);
            }

            Console.WriteLine("\tUseSwaggerUI");
            try
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/v2/api-docs", application_name);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tUseSwaggerUI Error:" + ex.Message);
            }
        }
    }
}
