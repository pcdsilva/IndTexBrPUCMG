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
    [RoutePrefix("api/GestaoProcessos")]
    public class GestaoProcessosController : ApiController
    {
        // GET: api/GestaoProcessos/RetornarNormas
        [HttpGet]
        [Route("RetornarNormas")]
        //[Authorize]
        public List<Norma> RetornarNormas()
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaNormas();
        }

        // GET: api/GestaoProcessos/RetornarNorma
        [HttpGet]
        [Route("RetornarNorma/{id:int}")]
        [Obsolete]
        //[Authorize]
        public Norma RetornarNorma(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaNorma(id);
        }

        // GET: api/GestaoProcessos/RetornarProcessos
        [HttpGet]
        [Route("RetornarProcessos")]
        //[Authorize]
        public IEnumerable<Processo> RetornarProcessos()
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos();
        }

        // GET: api/GestaoProcessos/RetornarProcesso/5
        [HttpGet]
        [Route("RetornarProcesso/{id:int}")]
        //[Authorize]
        public Processo RetornarProcesso(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();

            return processosDAO.ListaProcessos().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/GestaoProcessos/InserirProcessos
        [HttpPost]
        [Route("InserirProcessos")]
        //[Authorize]
        public List<Processo> InserirProcessos(Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Inserir(processo);

            return processosDAO.ListaProcessos();

        }

        // PUT: api/GestaoProcessos/AtualizarProcessos/5
        [HttpPut]
        [Route("AtualizarProcessos/{id:int}")]
        //[Authorize]
        public Processo AtualizarProcessos(int id, Processo processo)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            return processosDAO.Atualizar(id, processo);
        }

        // DELETE: api/GestaoProcessos/DeletarProcessos/5
        [HttpDelete]
        [Route("DeletarProcessos/{id:int}")]
        //[Authorize]
        public void DeletarProcessos(int id)
        {
            ProcessosDAO processosDAO = new ProcessosDAO();
            processosDAO.Deletar(id);
        }
    }
}
