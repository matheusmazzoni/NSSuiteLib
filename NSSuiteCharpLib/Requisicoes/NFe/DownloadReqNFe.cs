
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.NFe.Emissoes
{
    public class DownloadReqNFe : TemplateDownloadReq
    {
        public string chNFe { get; set; }
        public bool printCEAN { get; set; }

        public override string GetChave()
        {
            return chNFe;
        }
        public override Projeto GetProjeto()
        {
            return Projeto.NFe;
        }
        public override string EnviarDownload(string caminho, bool exibirNaTela)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            string url = Endpoints.BPeDownload;
            string msgLog = "DONWLOAD_NFe";
            return RequisitarNaAPI(conteudo, url, msgLog);
        }

    }
}