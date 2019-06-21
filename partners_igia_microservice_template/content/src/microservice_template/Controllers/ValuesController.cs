using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using microservice_template.Service;
using Serilog;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace microservice_template.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return ValuesService.GetValues();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return ValuesService.GetValue(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ReturnStatus> Post(string value)
        {
            return ValuesService.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<ReturnStatus> Put(int id, string value)
        {
            return ValuesService.Insert(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<ReturnStatus> Delete(int id)
        {
            return ValuesService.DeleteValue(id);
        }
    }
}
