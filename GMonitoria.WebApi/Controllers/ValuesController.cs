using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Repositories;

namespace GMonitoria.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private IProcessoSeletivoRepository _rep; 

        public ValuesController(IProcessoSeletivoRepository rep)
        {
            this._rep = rep;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ProcessoSeletivo> Get()
        {
            return _rep.GetAll();
            //return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
