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
    public class ConsultoriaAcessoriaController : ApiController
    {
        [HttpGet]
        [Authorize]
        public List<Norma> RetornarNormas()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNormas();
        }

        // GET: api/GestaoProcessos/RetornarNorma
        [HttpGet]
        [Obsolete]
        public Norma RetornarNorma(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaNorma(id);
        }

        // GET: api/ConsultoriaAcessoria/RetornarConsultorias
        public IEnumerable<Consultoria> RetornarConsultorias()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias();
        }

        // GET: api/ConsultoriaAcessoria/RetornarConsultoria/5
        public Consultoria RetornarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/ConsultoriaAcessoria/InserirConsultoria
        public List<Consultoria> InserirConsultoria(Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Inserir(consultoria);

            return consultoriaDAO.ListaConsultorias();

        }

        // PUT: api/ConsultoriaAcessoria/AtualizarConsultoria/5
        public Consultoria AtualizarConsultoria(int id, Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            return consultoriaDAO.Atualizar(id, consultoria);
        }

        // DELETE: api/ConsultoriaAcessoria/DeletarConsultoria/5
        public void DeletarConsultoria(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Deletar(id);
        }
    }
}
