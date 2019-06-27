using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Framework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace microservice_template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string error_message;
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string start_time = DateTime.Now.ToString();
            string environment = String_Helper.CheckString(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production");
			string config_name = "DEFAULT";

			if (environment == "Development")
			{
				config_name = String_Helper.CheckString(Environment.GetEnvironmentVariable("CONFIGURATION_NAME"), "STANDALONE");
			}

			if (args.Length == 1)
			{
				if (args[0].ToLower() == "standalone")
				{
					config_name = "STANDALONE";
				}
			}

            Console.WriteLine("Executing:" + name + ":" + version + " config:" + config_name + " at " + start_time + System.Environment.NewLine);
            switch (config_name)
            {
                case "STANDALONE":
                    string port = String_Helper.CheckString(Environment.GetEnvironmentVariable("PORT"), "8080");
                    BuildWebHost_Simple_Startup(args,port).Run();
                    break;
                                    
                case "DEFAULT":
                    int sleep = 0;
                    string sleep_param = String_Helper.CheckString(Environment.GetEnvironmentVariable("JHIPSTER_SLEEP"), "0");

                    if (Int32.TryParse(sleep_param, out sleep))
                    {
                        error_message = "";
                        Console.WriteLine("The application will start in " + sleep + "s...");
                        Thread.Sleep(sleep * 1000);

                        bool is_ok = Igia_Helper.Check_Environment(ref error_message);

                        if (is_ok)
                        {
                            string instance_host = "";
                            string status = "";

                            bool ip_ok = Igia_Helper.GetLocalIPAddress(ref instance_host, ref status, ref error_message);

                            if (ip_ok)
                            {
                                Console.Write(status);                                
                                BuildWebHost_Igia(args).Run();
                            }
                            else
                            {
                                Console.Write("IP Error:" + Environment.NewLine);
                                Console.Write(error_message);
                            }
                        }
                        else
                        {
                            Console.Write(error_message);
                        }
                    }
                    else
                    {
                        error_message = "Invalid Value " + sleep_param + " for JHIPSTER_SLEEP.";
                        Console.Write(error_message);
                    }
					if (Environment.OSVersion.Platform.ToString().StartsWith("Win"))
					{
						Console.Write("Press any key to exit"); Console.Read();
					}
					break;
				default:
					error_message = "CONFIGURATION_NAME:" + config_name + " is not valid";
                    Console.Write(error_message);
                    break;
            }
        }

        public static IWebHost BuildWebHost_Igia(string[] args)
        {
            IConfigurationRoot config_args = new ConfigurationBuilder().AddCommandLine(args).Build();

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddConfigServer()
                .Build();

           
            string instance_port = config["eureka:instance:port"];


            IWebHost host = WebHost.CreateDefaultBuilder(args)
           .UseUrls("http://0.0.0.0:" + instance_port)
           .UseContentRoot(Directory.GetCurrentDirectory())
           .UseConfiguration(config)
           .UseStartup<StartupIgia>()
           .Build();


            return host;
        }

        public static IWebHost BuildWebHost_Simple_Startup(string[] args, string port)
        {
			var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Standalone.json", false)
            .Build();
			
            IWebHost host = WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://0.0.0.0:" + port)
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();
            
            return host;
        }
    }
}
