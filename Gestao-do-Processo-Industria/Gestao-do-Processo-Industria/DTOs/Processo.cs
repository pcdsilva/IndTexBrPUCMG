using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestao_do_Processo_Industria.DTOs
{
    public class Processo
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal precoVenda { get; set; }
        public decimal custo { get; set; }
        public int QatdeMarquinasUtilizadas { get; set; }
        public int horasEstimadas { get; set; }
        public Norma norma { get; set; }
    }
}