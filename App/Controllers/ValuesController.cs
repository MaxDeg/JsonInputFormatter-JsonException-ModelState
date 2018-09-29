using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        [HttpPost("echo2")]
        public IActionResult Post2([FromForm] Model value)
        {
            return Ok(value);
        }
    }

    public class Model
    {
        [JsonProperty("id", Required = Required.Always)]
        [Required, BindRequired]
        public int Id { get; set; }
    }
}
