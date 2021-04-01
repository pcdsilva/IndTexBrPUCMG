using System;
using Confluent.Kafka;
using Sap.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Sap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SapController
    {

        private readonly ProducerConfig config;
        public SapController(ProducerConfig config)
        {
            this.config = config;
        }

        [HttpPost]
        [Route("NovoProcesso")]
        public async Task NovoProcesso([FromBody] Processo processo)
        {
            var produtor = new ProducerWrapper(this.config, "product_topic");
            await produtor.EnviarMessage(JsonConvert.SerializeObject(processo));
        }
    }
}
