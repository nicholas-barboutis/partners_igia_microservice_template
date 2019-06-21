using System;
using System.Collections.Generic;

namespace microservice_template.Service
{
    public class ReturnStatus
    {
        public string Status;
        public string Error;
    }

    static class ValuesService
    {
        static readonly List<string> _list = new List<string> { "value_1", "value_2" };

        public static List<string> GetValues()
        {
            return _list;
        }

        public static string GetValue(int id)
        {
            string value = "value";
            if (id >= 0 && id < _list.Count)
            {
                value =  _list[id];
            }
            return value;
        }

        public static ReturnStatus Add(string value)
        {
            ReturnStatus ret = new ReturnStatus();
            ret.Status = "OK";
            ret.Error = "";

            try
            {
                _list.Add(value);
            }
            catch (Exception ex)
            {
                ret.Status = "ERROR";
                ret.Error = ex.Message;
            }

            return ret;
        }

        public static ReturnStatus Insert(int id, string value)
        {
            ReturnStatus ret = new ReturnStatus();
            ret.Status = "OK";
            ret.Error = "";

            try
            {
                if (id >= 0 && id < _list.Count)
                {
                    _list.Insert(id, value);
                }
                else
                {
                    ret.Status = "ERROR";
                    ret.Error = "Index " + id + " does not exist.";
                }
            }
            catch (Exception ex)
            {
                ret.Status = "ERROR";
                ret.Error = ex.Message;
            }
            return ret;
        }


        public static ReturnStatus DeleteValue(int id)
        {
            ReturnStatus ret = new ReturnStatus();
            ret.Status = "OK";
            ret.Error = "";

            try
            {
                if (id >= 0 && id < _list.Count)
                {
                    _list.RemoveAt(id);
                }
                else
                {
                    ret.Status = "ERROR";
                    ret.Error = "Index " + id + " does not exist.";
                }
            }
            catch (Exception ex)
            {
                ret.Status = "ERROR";
                ret.Error = ex.Message;
            }

            return ret;

        }
    }
}
