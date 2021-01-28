using Consultoria_e_Acessoria.DTOs;
using Consultoria_e_Acessoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consultoria_e_Acessoria.Controllers
{
    public class ConsultoriaAcessoriaController : ApiController
    {
        // GET: api/ConsultoriaAcessoria
        public IEnumerable<Consultoria> Get()
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias();
        }

        // GET: api/ConsultoriaAcessoria/5
        public Consultoria Get(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();

            return consultoriaDAO.ListaConsultorias().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/ConsultoriaAcessoria
        public List<Consultoria> Post(Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Inserir(consultoria);

            return consultoriaDAO.ListaConsultorias();

        }

        // PUT: api/ConsultoriaAcessoria/5
        public Consultoria Put(int id, Consultoria consultoria)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            return consultoriaDAO.Atualizar(id, consultoria);
        }

        // DELETE: api/ConsultoriaAcessoria/5
        public void Delete(int id)
        {
            ConsultoriaDAO consultoriaDAO = new ConsultoriaDAO();
            consultoriaDAO.Deletar(id);
        }
    }
}
