
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.CTe.Emissao
{
    public class DownloadReqCTe : DownloadReq
    {
        public string chCTe { get; set; }
        public string CNPJ { get; set; }

        public override string EnviarDownload()
        {
            return DownlaodEmissao(Projeto.CTe, JsonConvert.SerializeObject(this), Endpoints.CTeDownload);
        }

        public override void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            DownlaodEmissaoComTratamento(this, caminho, chCTe, exibirNaTela);
        }
    }
}