using System;
namespace Framework
{
    internal class String_Helper
    {
        internal static string CheckString(string value, string default_val)
        {
            return String.IsNullOrWhiteSpace(value) ? default_val : value;
        }
    }
}
