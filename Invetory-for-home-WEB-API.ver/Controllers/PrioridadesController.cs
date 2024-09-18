﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invetory_for_home_WEB_API.ver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        // GET: api/<PrioridadesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrioridadesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrioridadesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrioridadesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrioridadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
