using System.Collections.Generic;

namespace NSSuiteCSharpLib.Respostas._Genericos
{
    public class EmissaoSincronaResp
    {
        public string statusEnvio { get; set; }
        public string statusConsulta { get; set; }
        public string statusDownload { get; set; }
        public string cStat{ get; set; }
        public string nProt { get; set; }
        public string motivo { get; set; }
        public string nsNRec { get; set; }
        public List<string> erros { get; set; }
    }
}
