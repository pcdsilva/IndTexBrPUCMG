using Consultoria_e_Acessoria.DTOs;
using Consultoria_e_Acessoria.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Consultoria_e_Acessoria.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ConsultoriaAcessoriaController : ApiController
    {
        // GET: api/ConsultoriaAcessoria
        [Authorize]
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
