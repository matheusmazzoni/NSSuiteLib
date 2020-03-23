
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.CTe.Emissao
{
    public class DownloadReqCTe : DownloadReq
    {
        public string chCTe { get; set; }
        public string CNPJ { get; set; }

        public override string EnviarDownload()
        {
            throw new System.NotImplementedException();
        }

        public override string EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            throw new System.NotImplementedException();
        }
    }
}