using Gestao_de_normas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gestao_de_normas.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class GestaoNormasController : ApiController
    {
        // GET: GestaoNormas/api/NormasExternas
        [HttpGet]
        [Route("NormasExternas")]

        [Authorize]
        public IEnumerable<Norma> RetornarNormasExternas()
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormasExternas();
        }

        // GET: GestaoNormas/api/NormasExternas/5
        [HttpGet]
        [Route("NormasExternas/{id:int}")]
        [Authorize]
        public Norma RetornarNormaExternas(int id)
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormasExternas().Where(x => x.id == id).FirstOrDefault();
        }

        // GET: GestaoNormas/api/Normas
        [HttpGet]
        [Route("Normas")]

        [Authorize]
        public IEnumerable<Norma> RetornarNormas()
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas();
        }

        // GET: GestaoNormas/api/Normas/5
        [HttpGet]
        [Route("Normas/{id:int}")]
        [Authorize]
        public Norma RetornarNorma(int id)
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas().Where(x=> x.id == id).FirstOrDefault();
        }

        // POST: GestaoNormas/api/Normas
        [HttpPost]
        [Route("Normas")]
        [Authorize]
        public List<Norma> InserirNorma(Norma norma)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Inserir(norma);

            return normaDAO.ListaNormas();

        }

        // PUT: GestaoNormas/api/Normas/5
        [HttpPut]
        [Route("Normas/{id:int}")]
        [Authorize]
        public Norma AtualizarNorma(int id, Norma norma)
        {
            NormasDAO normasDAO = new NormasDAO();
            return normasDAO.Atualizar(id, norma);
        }

        // DELETE: GestaoNormas/api/Normas/5
        [HttpDelete]
        [Route("Normas/{id:int}")]
        [Authorize]
        public void DeletarNorma(int id)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Deletar(id);
        }
    }
}
