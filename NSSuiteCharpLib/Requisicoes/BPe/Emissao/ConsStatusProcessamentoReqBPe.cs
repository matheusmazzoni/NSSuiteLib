using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas.BPe.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class ConsStatusProcessamentoReqBPe : TemplateConsStatusProcessamentoReq
    {
        public override ConsStatusProcessamentoResp ConsultaStatusProcesamentoDFe()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            string url = Endpoints.BPeConsStatusProcessamento;
            string msgLog = "CONSULTA_STATUS_PROCESSAMENTO_BPe";
            string resposta = Requisicao.RequisitarNaAPI(conteudo, url, msgLog);
            return JsonConvert.DeserializeObject<ConsStatusProcessamentoRespBPe>(resposta);
        }
    }
}

