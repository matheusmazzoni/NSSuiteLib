using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas._Genéricas
{
    public class CancelarResp : Evento
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public RetEvento retEvento { get; set; }
        public List<string> erros { get; set; }
        public Erro erro { get; set; }

    }
}