using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes.BPe;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas._Genericos;
using System.Collections.Generic;
using System.Threading;

namespace NSSuiteCSharpLib.Respostas.BPe
{
    public class EmitirRespBPe : EmitirResp
    {
        public string chBPe { get; set; }
    }
}
