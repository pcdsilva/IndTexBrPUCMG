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
        // GET: api/GestaoNormas
        public IEnumerable<Norma> Get()
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas();
        }

        // GET: api/GestaoNormas/5
        public Norma Get(int id)
        {
            NormasDAO normasDAO = new NormasDAO();

            return normasDAO.ListaNormas().Where(x=> x.id == id).FirstOrDefault();
        }

        // POST: api/GestaoNormas
        public List<Norma> Post(Norma norma)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Inserir(norma);

            return normaDAO.ListaNormas();

        }

        // PUT: api/GestaoNormas/5
        public Norma Put(int id, Norma norma)
        {
            NormasDAO normasDAO = new NormasDAO();
            return normasDAO.Atualizar(id, norma);
        }

        // DELETE: api/GestaoNormas/5
        public void Delete(int id)
        {
            NormasDAO normaDAO = new NormasDAO();
            normaDAO.Deletar(id);
        }
    }
}
