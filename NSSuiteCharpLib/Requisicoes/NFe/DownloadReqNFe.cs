
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.NFe.Emissoes
{
    public class DownloadReqNFe : DownloadReq
    {
        public string chNFe { get; set; }
        public bool printCEAN { get; set; }

        public override string EnviarDownload()
        {
            throw new System.NotImplementedException();
        }

        public override void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            throw new System.NotImplementedException();
        }
    }
}