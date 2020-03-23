using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Respostas._Genéricas;

namespace NSSuiteCSharpLib.Respostas.CTe
{
    public class CancelarRespCTe : CancelarResp
    {
        public new RetEventoCTe retEvento { get; set; }
    }
}