
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Respostas.CTe;
using System;

namespace NSSuiteCSharpLib.Requisicoes.CTe
{
    public class CancelarReqCTe : CancelarReq
    {
        public string chCTe { get; set; }

        public override string EnviarCancelamento(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            if (a3)
                AssinarXMLCancelamento(conteudo, cnpjEmitente);
            return RequisitarNaAPI(conteudo, Endpoints.CTeCancelamento, "CANCELAMENTO_CTe");
        }

        public override string EnviarCancelamentoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            return ValidarCancelamento(downloadEventoReq, cnpjEmitente, caminho, exibirNaTela, a3);
        }
        public override string AssinarXMLCancelamento(string conteudo, string cnpjEmitente)
        {
            throw new NotImplementedException("Função de Assinatura de XML para CTe ainda nao foi implementada! Coloque o parametro a3 como False");
        }

        public override string GerarXMLCancelamento(string conteudo, string tpConteudo)
        {
            throw new NotImplementedException("Função de Geração de XML para CTe ainda nao foi implementada!");
        }
    }
}