using NSSuiteCSharpLib;
using NSSuiteCSharpLib.Genericos;
using testeLib.Modelos;

namespace testeLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Comuns.gravarLinhaLog("TESTE_MILI_INCIO");
            NSSuite ns = new NSSuite("4EB15D6DEDAEBAE3FD0B7B5E5B0AD6D4");
            TemplateBPe templateBPe = new TemplateBPe();
            ns.EmitirDocumentoSincrono(templateBPe.BPe, "XP", @".\Documentos\", true);
            Comuns.gravarLinhaLog("TESTE_MILI_FINAL");
        }
    }
}
