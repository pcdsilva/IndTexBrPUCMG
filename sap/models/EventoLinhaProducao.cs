using System;

namespace Sap.models
{
    public class EventoLinhaProducao
    {
        public Guid idLinhaProducao { get; set; }
        public string descricao { get; set; }
        public DateTime inicio { get; set; }
        public TipoEventoLinhaProducao tipoEvento { get; set; }
    }
}