using Gestao_do_Processo_Industria.DTOs;
using Gestao_do_Processo_Industria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gestao_do_Processo_Industria.Controllers
{
    public class GestaoProcessosController : ApiController
    {
        // GET: api/GestaoProcesso
        public IEnumerable<Processo> Get()
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos();
        }

        // GET: api/GestaoProcesso/5
        public Processo Get(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/GestaoProcesso
        public List<Processo> Post(Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Inserir(processo);

            return processosDAO.ListaProcessos();

        }

        // PUT: api/GestaoProcesso/5
        public Processo Put(int id, Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            return processosDAO.Atualizar(id, processo);
        }

        // DELETE: api/GestaoProcesso/5
        public void Delete(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Deletar(id);
        }
    }
}
