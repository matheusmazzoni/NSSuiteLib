using NSSuiteCSharpLib;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes.BPe;
using testeLib.Modelos;

namespace testeLib
{
    class Program
    {
        static void Main(string[] args)
        {
            
            NSSuite ns = new NSSuite("4EB15D6DEDAEBAE3FD0B7B5E5B0AD6D4");
            TemplateBPe templateBPe = new TemplateBPe();
            ns.EmitirDocumentoSincrono(templateBPe.BPe, "XP", @".\Documentos\", true);
            
        }
    }
}
