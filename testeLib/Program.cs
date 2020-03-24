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
            NSSuite ns = new NSSuite("4EB15D6DEDAEBAE3FD0B7B5E5B0AD6D4");
            TemplateBPe templateBPe = new TemplateBPe();
            ns.EmitirDocumentoSincrono(templateBPe.BPeRoot, "XP", @"C:\", false, true);
        }
    }
}
