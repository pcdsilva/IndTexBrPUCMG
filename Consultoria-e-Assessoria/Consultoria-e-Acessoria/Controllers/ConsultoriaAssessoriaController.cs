using Consultoria_e_Assessoria.DTOs;
using Consultoria_e_Assessoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Consultoria_e_Assessoria.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class ConsultoriaAssessoriaController : ApiController
    {
        // GET: ConsultoriaAssessoria/api/Normas
        [HttpGet]
        [Route("Normas")]
        [Authorize]
        public List<Norma> RetornarNormas()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNormas();
        }

        // GET: ConsultoriaAssessoria/api/Normas/5
        [HttpGet]
        [Obsolete]
        [Route("Normas/{id:int}")]
        [Authorize]
        public Norma RetornarNorma(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNorma(id);
        }

        [HttpGet]
        [Route("Consultorias")]
        [Authorize]
        // GET: ConsultoriaAssessoria/api/Consultorias
        public IEnumerable<Consultoria> RetornarConsultorias()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias();
        }

        [HttpGet]
        [Route("Consultorias/{id:int}")]
        [Authorize]
        // GET: ConsultoriaAssessoria/api/Consultorias/5
        public Consultoria RetornarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias().Where(x => x.id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("Consultorias")]
        [Authorize]
        // POST: ConsultoriaAssessoria/api/Consultorias
        public List<Consultoria> InserirConsultoria(Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Inserir(consultoria);

            return consultoriaDAO.ListaConsultorias();

        }


        [HttpPut]
        [Route("Consultorias/{id:int}")]
        [Authorize]
        // PUT: ConsultoriaAssessoria/api/Consultorias/5
        public Consultoria AtualizarConsultoria(int id, Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            return consultoriaDAO.Atualizar(id, consultoria);
        }

        [HttpDelete]
        [Route("Consultorias/{id:int}")]
        [Authorize]
        // DELETE: ConsultoriaAssessoria/api/Consultorias/5
        public void DeletarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Deletar(id);
        }
    }
}
