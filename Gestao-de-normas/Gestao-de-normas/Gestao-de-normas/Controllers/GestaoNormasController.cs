using Gestao_de_normas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gestao_de_normas.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/GestaoNormas")]
    public class GestaoNormasController : ApiController
    {
        // GET: api/GestaoNormas/RetornarNormas
        [HttpGet]
        [Route("RetornarNormas")]
        //[Authorize]
        public IEnumerable<Norma> RetornarNormas()
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas();
        }

        // GET: api/GestaoNormas/RetornarNorma/5
        [HttpGet]
        [Route("RetornarNorma/{id:int}")]
        //[Authorize]
        public Norma RetornarNorma(int id)
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas().Where(x=> x.id == id).FirstOrDefault();
        }

        // POST: api/GestaoNormas/InserirNorma
        [HttpPost]
        [Route("InserirNorma/norma")]
        //[Authorize]
        public List<Norma> InserirNorma(Norma norma)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Inserir(norma);

            return normaDAO.ListaNormas();

        }

        // PUT: api/GestaoNormas/AtualizarNorma/5
        [HttpPut]
        [Route("AtualizarNorma/{id:int}/norma")]
        //[Authorize]
        public Norma AtualizarNorma(int id, Norma norma)
        {
            NormasDAO normasDAO = new NormasDAO();
            return normasDAO.Atualizar(id, norma);
        }

        // DELETE: api/GestaoNormas/DeletarNorma/5
        [HttpDelete]
        [Route("DeletarNorma/{id:int}")]
        //[Authorize]
        public void DeletarNorma(int id)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Deletar(id);
        }
    }
}
