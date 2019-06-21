using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework
{
	/// <summary>
	/// An object used with the DI Options mechanism for exposing the data retrieved 
	/// from the Spring Cloud Config Server
	/// </summary>
    ///

	public class Service_Config
	{
		public string server { get; set; }
        public string service_path { get; set; }
        public string instance_id { get; set; }
	}
}