using System;
namespace Framework
{
    public class Exception_Helper
    {
        public Exception_Helper()
        {
        }

        public static string ProcessException(Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            return ex.Message;
        }
    }
}
