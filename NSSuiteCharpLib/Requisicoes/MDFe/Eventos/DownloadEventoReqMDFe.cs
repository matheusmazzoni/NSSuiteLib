
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;

namespace NSSuiteCSharpLib.Requisicoes.MDFe
{
    public class DownloadEventoReqMDFe : DownloadEventoReq
    {
        public string chMDFe { get; set; }

        public override string EnviarDownloadEvento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.MDFeDownloadEvento, "DOWNLOAD_EVENTO_MDFe");
        }

        public override void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela)
        {
            ValidarDownloadEvento(caminho, tpEvento + chMDFe, exibirNaTela);
        }
    }
}