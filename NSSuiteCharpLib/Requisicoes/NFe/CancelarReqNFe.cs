
using Newtonsoft.Json;
using System;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Respostas.NFe;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;

namespace NSSuiteCSharpLib.Requisicoes.NFe
{
    public class CancelarReqNFe : CancelarReq 
    { 

        public string chNFe { get; set; }

        public override string EnviarCancelamento(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.NFCeCancelamento, "CANCELAMENTO_NFe");  
        }
        public override string EnviarCancelamentoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            return ValidarCancelamento(downloadEventoReq, cnpjEmitente, caminho, exibirNaTela, a3);
        }
        public override string GerarXMLCancelamento(string conteudo, string tpConteudo)
        {
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.NFeGerarXMLCancelamento, "GERACAO_XML_CANCELAMENTO_NFe");
        }
    }
}
