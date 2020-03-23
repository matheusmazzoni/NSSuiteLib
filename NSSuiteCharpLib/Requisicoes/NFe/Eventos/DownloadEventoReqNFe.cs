
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;

namespace NSSuiteCSharpLib.Requisicoes.NFe
{
    public class DownloadEventoReqNFe : DownloadEventoReq
    {
        public string chNFe { get; set; }

        public override string EnviarDownloadEvento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.NFeDownload, "DOWNLOAD_EVENTO_NFe");
        }
        public override void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela)
        {
            ValidarDownloadEvento(caminho, tpEvento + chNFe, exibirNaTela);
        }
    }
}