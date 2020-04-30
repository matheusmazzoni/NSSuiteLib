
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class DownloadReqBPe : TemplateDownloadReq
    {
        [JsonProperty("chBPe")]
        public string ChaveBPe { get; set; }
        public override string GetChave()
        {
            return ChaveBPe;
        }
        public override Projeto GetProjeto()
        {
            return Projeto.BPe;
        }
        public override string EnviarDownload(string caminho, bool exibirNaTela)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            string url = Endpoints.BPeDownload;
            string msgLog = "DONWLOAD_BPe";
            return RequisitarNaAPI(conteudo, url, msgLog);
        }
    }
}
