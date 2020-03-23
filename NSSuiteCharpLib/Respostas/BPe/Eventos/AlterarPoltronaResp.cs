using NSSuiteCharpLib.Respostas._Genéricas.Eventos;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas.BPe;

namespace NSSuiteCharpLib.Respostas.BPe.Eventos
{
    public class AlterarPoltronaResp
    {
        public string status { get; set; }
        public string motivo { get; set; }
        public RetEventoBPeXml retEvento { get; set; }
        public Erro erro { get; set; }
    }
}
