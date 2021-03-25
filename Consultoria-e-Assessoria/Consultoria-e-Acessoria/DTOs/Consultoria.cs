using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultoria_e_Assessoria.DTOs
{
    public class Consultoria
    {
        public int id { get; set; }
        public string departamento { get; set; }
        public string setor { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }
        public string dtContratacao { get; set; }
        public string periodoContratacao { get; set; }
        public string ativo { get; set; }
        public string dtInicio { get; set; }
        public string dtTermino { get; set; }

        public string norma { get; set; }
        public string descricao { get; set; }
    }
}