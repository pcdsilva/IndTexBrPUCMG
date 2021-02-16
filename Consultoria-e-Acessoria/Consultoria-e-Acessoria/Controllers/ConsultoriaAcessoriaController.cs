using Consultoria_e_Acessoria.DTOs;
using Consultoria_e_Acessoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Consultoria_e_Acessoria.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class ConsultoriaAcessoriaController : ApiController
    {
        // GET: ConsultoriaAcessoria/api/Normas
        [HttpGet]
        [Route("Normas")]
        //[Authorize]
        public List<Norma> RetornarNormas()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNormas();
        }

        // GET: ConsultoriaAcessoria/api/Normas/5
        [HttpGet]
        [Obsolete]
        [Route("Normas/{id:int}")]
        //[Authorize]
        public Norma RetornarNorma(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNorma(id);
        }

        [HttpGet]
        [Route("Consultorias")]
        //[Authorize]
        // GET: ConsultoriaAcessoria/api/Consultorias
        public IEnumerable<Consultoria> RetornarConsultorias()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias();
        }

        [HttpGet]
        [Route("Consultorias/{id:int}")]
        //[Authorize]
        // GET: ConsultoriaAcessoria/api/Consultorias/5
        public Consultoria RetornarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias().Where(x => x.id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("Consultorias")]
        //[Authorize]
        // POST: ConsultoriaAcessoria/api/Consultorias
        public List<Consultoria> InserirConsultoria(Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Inserir(consultoria);

            return consultoriaDAO.ListaConsultorias();

        }


        [HttpPut]
        [Route("Consultorias/{id:int}")]
        //[Authorize]
        // PUT: ConsultoriaAcessoria/api/Consultorias/5
        public Consultoria AtualizarConsultoria(int id, Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            return consultoriaDAO.Atualizar(id, consultoria);
        }

        [HttpDelete]
        [Route("Consultorias/{id:int}")]
        //[Authorize]
        // DELETE: ConsultoriaAcessoria/api/Consultorias/5
        public void DeletarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Deletar(id);
        }
    }
}
