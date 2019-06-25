using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Framework;
using Microsoft.Extensions.Configuration;

namespace Framework
{
    internal class HIP_Helper
    {
        internal static Dictionary<string, string> Create_Dictionary(string instance_host, string version)
        {
            string app_name = String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_APPLICATION_NAME"), "");
            string instance_id = app_name + ":" + Guid.NewGuid().ToString("N");
			string environment = String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_CLOUD_CONFIG_ENV"), "");
			string zone = "primary";


			Dictionary<string, string> hip_environment = new Dictionary<string, string> {
				{ "spring:application:name" , app_name },
				{ "spring:cloud:config:uri" , String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_CLOUD_CONFIG_URI"), "") },
				{ "spring:cloud:config:env" , String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_CLOUD_CONFIG_ENV"), "") },
				{ "spring:cloud:config:label" , String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_CLOUD_CONFIG_LABEL"), "") },
				{ "spring:profiles:active" , String_Helper.CheckString(Environment.GetEnvironmentVariable("SPRING_PROFILES_ACTIVE"), "") },
				{ "eureka:client:serviceUrl" , String_Helper.CheckString(Environment.GetEnvironmentVariable("EUREKA_CLIENT_SERVICE_URL_DEFAULTZONE"), "") },
				{ "eureka:client:shouldFetchRegistry" , "False" },
				{ "eureka:instance:port", String_Helper.CheckString(Environment.GetEnvironmentVariable("EUREKA_INSTANCE_PORT"), "") },
				{ "eureka:instance:instanceId" , instance_id },
				{ "eureka:instance:hostname" , instance_host },
				{ "eureka:instance:metadataMap:zone" , zone },
				{ "eureka:instance:metadataMap:profile" , environment},
				{ "eureka:instance:metadataMap:version" , version},
				{ "eureka:instance:metadataMap:test" , "test" },
				{ app_name + ":instance_id", instance_id}
			};
            return hip_environment;
        }

        internal static bool Check_Environment(ref string error)
        {

            bool is_error;
            bool is_ok;
            string value;
            string error_message;

            is_ok = true;

            HashSet<string> required_params = new HashSet<string>();
            required_params.Add("SPRING__APPLICATION__NAME");
            required_params.Add("SPRING__CLOUD__CONFIG__URI");
            required_params.Add("SPRING__CLOUD__CONFIG__ENV");
            required_params.Add("SPRING__CLOUD__CONFIG__LABEL");
            required_params.Add("SPRING__PROFILES__ACTIVE");
            required_params.Add("EUREKA__CLIENT__SERVICE__URL__DEFAULTZONE");
            required_params.Add("EUREKA__INSTANCE__PORT");

            foreach (string param in required_params)
            {
                value = String_Helper.CheckString(Environment.GetEnvironmentVariable(param), "");
                is_error = (value == "") ? true : false;
                error_message = (is_error) ? param + " is missing" + Environment.NewLine : "";
                if (is_error == true)
                {
                    is_ok = false;
                    error += error_message;
                }
            }
            return is_ok;
        }

        public static bool GetLocalIPAddress(ref string ip_address, ref string status, ref string error)
        {
            bool is_ok;

            is_ok = true;
            ip_address = "";
            error = "";
            status = "";

            status += String.Format("Network Information" + Environment.NewLine);

            try
            {
                string host_name = Dns.GetHostName();
                status += "\tHostName = " + host_name + Environment.NewLine;
                try
                {
                    IPHostEntry host = Dns.GetHostEntryAsync(host_name).Result;
                    try
                    {
                        status += String.Format("\tAddress List: " + Environment.NewLine);
                        if (host.AddressList.Count() == 0)
                        {
                            is_ok = false;
                            error = String.Format("Error: No IP Addresses found.");
                            status += error + Environment.NewLine;
                        }
                        else
                        {
                            foreach (IPAddress ip_addr in host.AddressList)
                            {
                                status += String.Format("\t\tAddress:{0}\t\tAddressFamily:{1}" + Environment.NewLine, ip_addr.ToString(), ip_addr.AddressFamily.ToString());
                            }

                            IPAddress ipx = host.AddressList.First();

                            try
                            {
                                ipx = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                            }
                            catch (Exception ex)
                            {
                                is_ok = false;
                                error = String.Format("Error: Could not find Inter Network address: Using First Address.");
                                status += error + Environment.NewLine + ex.Message;
                            }

                            ip_address = ipx.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        is_ok = false;
                        error = String.Format("Error: Could not identify IPAddress") + Environment.NewLine + ex.Message;
                        status += error + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    is_ok = false;
                    error = String.Format("Error: Could not resolve hostname:" + host_name ) + Environment.NewLine + ex.Message;
                    status += error + Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
                is_ok = false;
                error = String.Format("Error: Could not determine hostname.") + Environment.NewLine + ex.Message;
                status += error + Environment.NewLine;
            }

            status += String.Format("\tMicroservice Address = {0} " + Environment.NewLine , ip_address);
            return is_ok;
        }
    }

}
