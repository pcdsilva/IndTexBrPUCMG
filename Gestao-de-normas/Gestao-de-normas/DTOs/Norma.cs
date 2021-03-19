using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestao_de_normas.Models
{
    public class Norma
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string nome { get; set; }
        public string anoPublicaçao { get; set; }
        public string dataAtualizacao { get; set; }
        public string descricao { get; set; }
        public string link { get; set; }
    }
}