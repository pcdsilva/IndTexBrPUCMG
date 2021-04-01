using System;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sap.models;

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
        [Route("nova-producao")]
        public async System.Threading.Tasks.Task NovaProducao([FromBody] LinhaProducao linhaProducao)
        {
            linhaProducao.inicio = DateTime.Now;
            var producer = new ProducerWrapper(this.config, "product_topic");
            Console.Write(linhaProducao);
            await producer.writeMessage(JsonConvert.SerializeObject(linhaProducao));
        }

        [HttpPost]
        [Route("novo-evento-producao")]
        public async System.Threading.Tasks.Task NovoEvento([FromBody] EventoLinhaProducao eventoLinhaProducao)
        {
            eventoLinhaProducao.inicio = DateTime.Now;
            var producer = new ProducerWrapper(this.config, "EVENTO_LINHA_PRODUCAO_CADASTRADO_DPI");
            await producer.writeMessage(JsonConvert.SerializeObject(eventoLinhaProducao));
        }
    }
}
