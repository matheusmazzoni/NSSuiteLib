using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class ConsStatusProcessamentoReqBPe : ConsStatusProcessamentoReq
    {
        public override string EnviarConsultaStatusProcesamento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.BPeConsStatusProcessamento, "CONSULTA_STATUS_PROCESSAMENTO_BPe");
        }
    }
}

