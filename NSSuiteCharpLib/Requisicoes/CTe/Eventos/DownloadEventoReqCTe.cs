
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;

namespace NSSuiteCSharpLib.Requisicoes.CTe
{
    public class DownloadEventoReqCTe : DownloadEventoReq
    {
        public string chCTe { get; set; }

        public override string EnviarDownloadEvento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.CTeDownloadEvento, "DOWNLOAD_EVENTO_CTe");
        }
        public override void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela)
        {
            ValidarDownloadEvento(caminho, tpEvento + chCTe, exibirNaTela);
        }
    }
}