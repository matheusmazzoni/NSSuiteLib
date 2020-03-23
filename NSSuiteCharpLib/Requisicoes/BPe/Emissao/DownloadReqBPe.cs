
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class DownloadReqBPe : DownloadReq
    {
        public string chBPe { get; set; }

        public override string EnviarDownload()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.BPeDownload, "DOWNLOAD_BPe"); 
        }

        public override string EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            return ValidarDownload(caminho, chBPe, exibirNaTela);
        }
    }
}
