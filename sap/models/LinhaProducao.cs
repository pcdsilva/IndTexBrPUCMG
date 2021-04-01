using System;

namespace Sap.models
{
    public class LinhaProducao
    {
        public Guid id { get; set; }
        public string descricao { get; set; }
        public decimal precoVenda { get; set; }
        public decimal custo { get; set; }
        public DateTime inicio { get; set; }
        public int qtdMaquinasUtilizadas { get; set; }
        public int horasEstimadas { get; set; }
    }
}