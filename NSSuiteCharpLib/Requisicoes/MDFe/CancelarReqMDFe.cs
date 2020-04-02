
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas.MDFe;
using System;

namespace NSSuiteCSharpLib.Requisicoes.MDFe
{
    public class CancelarReqMDFe : CancelarReq
    {
        public string chMDFe { get; set; }

        public override string EnviarCancelamento(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.MDFeCancelamento, "CANCELAMENTO_MDFe");
        }

        public override string EnviarCancelamentoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            return ValidarCancelamento(downloadEventoReq, cnpjEmitente, caminho, exibirNaTela, a3);
        }

        public override string GerarXMLCancelamento(string conteudo, string tpConteudo)
        {
            throw new NotImplementedException("Função de Geração de XML para MDFe ainda nao foi implementada!");
        }
    }
}