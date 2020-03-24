
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
            return DownlaodEmissao(Projeto.BPe, JsonConvert.SerializeObject(this), Endpoints.BPeDownload);
        }
        public override void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            DownlaodEmissaoComTratamento(this, caminho, chBPe, exibirNaTela);
        }
    }
}
