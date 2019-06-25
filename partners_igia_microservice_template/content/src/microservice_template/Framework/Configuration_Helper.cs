using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Framework
{
    public class Configuration_Helper
    {
        public Configuration_Helper()
        {
        }


        public static void write_config(string message, IConfiguration config)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-----------------------------------");
            foreach (KeyValuePair<string, string> x in config.AsEnumerable())
            {
                Console.WriteLine(x.Key + " = " + x.Value);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        } 

    }
}
