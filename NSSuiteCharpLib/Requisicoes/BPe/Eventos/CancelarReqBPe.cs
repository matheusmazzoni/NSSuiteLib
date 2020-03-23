
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using System;

namespace NSSuiteCSharpLib.Requisicoes.BPe.Eventos
{
    public class CancelarReqBPe : CancelarReq
    {
        public string chBPe { get; set; }

        public override string EnviarCancelamento(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            if (a3)
                AssinarXMLCancelamento(conteudo, cnpjEmitente);
            return RequisitarNaAPI(conteudo, Endpoints.BPeCancelamento, "CANCELAMENTO_BPe");
        }
        public override string EnviarCancelamentoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            return ValidarCancelamento(downloadEventoReq, cnpjEmitente, caminho, exibirNaTela, a3);
        }

        public override string AssinarXMLCancelamento(string conteudo, string cnpjEmitente)
        {
            throw new NotImplementedException("Função de Assinatura de XML de Cancelamento para BPe ainda nao foi implementada!");
        }

        public override string GerarXMLCancelamento(string conteudo, string tpConteudo)
        {
            throw new NotImplementedException("Função de Geração de XML de Cancelamento para BPe ainda nao foi implementada!");
        }
    }
}