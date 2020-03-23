using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas._Genéricas
{
    public abstract class ConsNaoEncerradosResp
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public IList<string> erros { get; set; }
        public Erro erro { get; set; }
    }
}