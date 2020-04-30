using NSSuiteCSharpLib.Respostas._Genéricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSuiteCSharpLib.Respostas._Genéricas.Emissoes
{
    public interface IEmitirResp
    {
        string status { get; set; }
        string motivo { get; set; }
        string xMotivo { get; set; }
        List<string> erros { get; set; }
        Erro erro { get; set; }
    }
}
