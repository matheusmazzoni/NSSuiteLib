using NSSuiteCSharpLib;
using NSSuiteCSharpLib.Requisicoes.BPe;
using NSSuiteCSharpLib.Requisicoes.CTe;
using NSSuiteCSharpLib.Requisicoes.NFe;
using NSSuiteCSharpLib.Respostas.BPe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeLib.Modelos;

namespace testeLib
{
    class Program
    {
        static void Main(string[] args)
        {
            NSSuite ns = new NSSuite("");
            TemplateBPe templateBPe = new TemplateBPe();
            EnvioReqBPe bpe = templateBPe.GetBPe();
            ns.EmitirDocumentoSincrono(bpe, @"C:\", bpe.BPe.infBPe.emit.CNPJ);
        }
    }
}
