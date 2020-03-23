
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Respostas.NFe;
using System;

namespace NSSuiteCSharpLib.Requisicoes._Genericos
{
    public class CorrigirReqNFe : CorrigirReq
    {
        public string chNFe { get; set; }
        public string xCorrecao { get; set; }

        public override string EnviarCorrecao(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            if (a3)
                AssinarXMLCorrecao(conteudo, cnpjEmitente);
            return RequisitarNaAPI(conteudo, Endpoints.NFeCCe, "CCE_NFe");
        }

        public override string EnviarCorrecaoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            return ValidarCartaCorrecao(downloadEventoReq, cnpjEmitente, caminho, exibirNaTela, a3);
        }

        public override string AssinarXMLCorrecao(string conteudo, string cnpjEmitente)
        {
            try
            {
                string respostaJSON = GerarXMLCorrecao(conteudo, "json");
                return ValidarAssinaturaXML(respostaJSON, cnpjEmitente, "infEvento");

            }
            catch (Exception)
            {
                throw new Exception("Problema na Assinatura do XML de CCe da NFe, " +
                    "verifique os logs para mais informações");
            }
        }

        public override string GerarXMLCorrecao(string conteudo, string tpConteudo)
        {
            return RequisitarNaAPI(conteudo, Endpoints.NFeGerarXMLCorrecao, "GERACAO_XML_CORRECAO_NFe");
        }
    }
}