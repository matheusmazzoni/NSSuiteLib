
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Requisicoes._Genericos.Utilitarios;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class ConsSitReqBPe : ConsSitReq
    {
        public string chBPe { get; set; }

        public override string EnviarConsultaSituacao()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.BPeConsSit, "CONSULTA_SITUACAO_BPe");
        }
    }
}
