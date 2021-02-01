using Gestao_de_normas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gestao_de_normas.Controllers
{
    public class GestaoNormasController : ApiController
    {
        // GET: api/GestaoNormas/RetornarNormas
        [HttpGet]
        public IEnumerable<Norma> RetornarNormas()
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas();
        }

        // GET: api/GestaoNormas/RetornarNorma/5
        [HttpGet]
        public Norma RetornarNorma(int id)
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas().Where(x=> x.id == id).FirstOrDefault();
        }

        // POST: api/GestaoNormas/InserirNorma
        [HttpPost]
        public List<Norma> InserirNorma(Norma norma)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Inserir(norma);

            return normaDAO.ListaNormas();

        }

        // PUT: api/GestaoNormas/AtualizarNorma/5
        [HttpPut]
        public Norma AtualizarNorma(int id, Norma norma)
        {
            NormasDAO normasDAO = new NormasDAO();
            return normasDAO.Atualizar(id, norma);
        }

        // DELETE: api/GestaoNormas/DeletarNorma/5
        [HttpDelete]
        public void DeletarNorma(int id)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Deletar(id);
        }
    }
}
