using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JsonInputFormatter_JsonException_ModelState.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("echo")]
        public IActionResult Post([FromBody] Model value)
        {
            return Ok(value);
        }
    }

    public class Model
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
    }
}
