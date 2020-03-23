using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas._Genéricas
{
    public abstract class IncCondutorResp
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public RetEvento retEvento { get; set; }
        public IList<string> erros { get; set; }
        public Erro erro { get; set; }
    }
}