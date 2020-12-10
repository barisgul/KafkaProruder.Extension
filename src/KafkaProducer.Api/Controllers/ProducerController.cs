using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KafkaProducer.Api.Filters;
using KafKaProducer.Aggregator.Models;
using KafKaProducer.Aggregator.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KafkaProducer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProducerController>
        [SwaggerRequestExample(typeof(ProducerInfo), typeof(ProducerModelExample))]
        [HttpPost("ProduceAsync")] 
        public List<ProducerResult> Produce(ProducerInfo info)  
        { 
            KafkaProducer.Produce(info, out List<ProducerResult> producerResult);

            return producerResult;
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
