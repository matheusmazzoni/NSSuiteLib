using NSSuiteCharpLib.Respostas._Genéricas.Eventos;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas.BPe.Eventos
{
    public class NaoEmbRespBPe
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public RetEventoBPeXml retEvento { get; set; }
        public List<string> erros { get; set; }
        public Erro erro { get; set; }
    }
}