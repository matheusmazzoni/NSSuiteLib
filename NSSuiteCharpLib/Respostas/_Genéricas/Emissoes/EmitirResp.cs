using NSSuiteCSharpLib.Respostas._Genéricas.Emissoes;
using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas._Genéricas
{
    public class EmitirResp : IEmitirResp
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public string xMotivo { get; set; }
        public List<string> erros { get; set; }
        public Erro erro { get; set; }
        public string nsNRec { get; set; }
    }
}