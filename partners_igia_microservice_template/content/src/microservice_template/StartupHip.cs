using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Framework;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace microservice_template
{ 
    public class StartupHip
    {
        public StartupHip(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureServices");
            string application_name = Configuration["spring:application:name"];
            Console.WriteLine("Application Name: " + application_name);

            Console.WriteLine("\tAddDiscoveryClient");
            try
            {

                var x = services.AddDiscoveryClient(Configuration);
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tAddDiscoveryClient Error:" + err_message);
            }

            Console.WriteLine("\tAddMvc");
            try
            {
                // Add framework services.
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tAddMvc Error:" + err_message);
            }

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
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tAddSwaggerGen Error:" + err_message);
            }

            Console.WriteLine("\tIConfiguration Singleton");
            try
            {
                //string config_name = application_name;
                // Add the configuration data returned from the Spring Cloud Config Server as IOption<>
                services.AddSingleton<IConfiguration>(Configuration);
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tIConfiguration Singleton Error:" + err_message);
            }

            Console.WriteLine("\tServiceInfo");
            try
            {
                IConfigurationSection section = Configuration.GetSection(application_name);
                services.Configure<Service_Config>(section);
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tSystemListServiceConfig Error:" + err_message);
            }

            Console.WriteLine("End ConfigureServices");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            Console.WriteLine("Configure Function");

            string application_name = Configuration["spring:application:name"];

            /*
            Console.WriteLine("\tAddConsole");
            try
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tAddConsole Error:" + err_message);
            }

            Console.WriteLine("\tAddDebug");
            try
            {
                loggerFactory.AddDebug();
            }
            catch (Exception ex)
            {
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tAddConsole Error:" + err_message);
            }
*/

            Console.WriteLine("\tUseMvc");
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
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tUseSwagger Error:" + err_message);
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
                string err_message = Exception_Helper.ProcessException(ex);
                Console.WriteLine("\t\tUseSwaggerUI Error:" + err_message);
            }

            Console.WriteLine("\tUseDiscoveryClient");
            try
            {
                app.UseDiscoveryClient();


                app.UseDiscoveryClient();

                DiscoveryClient client = (DiscoveryClient)app.ApplicationServices.GetRequiredService<IDiscoveryClient>();

                if (client.LastGoodRegisterTimestamp > 0)
                {
                    Console.WriteLine("\t\tRegistration Successfull");
                }
                else
                {
                    throw new Exception("Eureka Registration Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tUseDiscoveryClient Error:" + ex.Message);
                throw ex;
            }

            Console.WriteLine("End Configure Function");

        }
    }
}
