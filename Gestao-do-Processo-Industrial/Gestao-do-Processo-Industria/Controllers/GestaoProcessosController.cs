using Gestao_do_Processo_Industrial.DTOs;
using Gestao_do_Processo_Industrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gestao_do_Processo_Industrial.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class GestaoProcessosController : ApiController
    {
        // GET: GestaoProcessos/api/Normas
        [HttpGet]
        [Route("Normas")]
        [Authorize]
        public List<Norma> RetornarNormas()
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaNormas();
        }

        // GET: GestaoProcessos/api/Normas/5
        [HttpGet]
        [Route("Normas/{id:int}")]
        [Obsolete]
        [Authorize]
        public Norma RetornarNorma(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaNorma(id);
        }

        // GET: GestaoProcessos/api/Processos
        [HttpGet]
        [Route("Processos")]
        [Authorize]
        public IEnumerable<Processo> RetornarProcessos()
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos();
        }

        // GET: GestaoProcessos/api/Processos/5
        [HttpGet]
        [Route("Processos/{id:int}")]
        [Authorize]
        public Processo RetornarProcesso(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: GestaoProcessos/api/Processos
        [HttpPost]
        [Route("Processos")]
        [Authorize]
        public List<Processo> InserirProcessos(Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Inserir(processo);

            return processosDAO.ListaProcessos();

        }

        // PUT: GestaoProcessos/api/Processos/5
        [HttpPut]
        [Route("Processos/{id:int}")]
        [Authorize]
        public Processo AtualizarProcessos(int id, Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            return processosDAO.Atualizar(id, processo);
        }

        // DELETE: GestaoProcessos/api/Processos/5
        [HttpDelete]
        [Route("Processos/{id:int}")]
        [Authorize]
        public void DeletarProcessos(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Deletar(id);
        }
    }
}
