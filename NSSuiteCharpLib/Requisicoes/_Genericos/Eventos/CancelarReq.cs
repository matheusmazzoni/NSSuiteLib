using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Eventos
{
    public abstract class CancelarReq : Evento
    {
        public string tpAmb { get; set; }
        public string dhEvento { get; set; }
        public string nProt { get; set; }
        public string xJust { get; set; }

       public abstract string EnviarCancelamento(string cnpjEmitente, bool a3);
       public abstract string EnviarCancelamentoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3);
       public abstract string GerarXMLCancelamento(string conteudo, string tpConteudo);
       protected virtual string ValidarCancelamento(DownloadEventoReq downloadEventoReq, string cnpjEmitente, string caminho, bool exibirNaTela, bool a3)
       {
            string resposta = EnviarCancelamento(cnpjEmitente, a3);
            var conteudo = JsonConvert.DeserializeObject<CancelarResp>(resposta);
            string status = conteudo.status;

            if (status.Equals("200"))
            {
                string cStat = conteudo.retEvento.cStat;
                if (cStat.Equals("135"))
                {
                    downloadEventoReq.EnviarDownloadEventoESalvar(caminho, "110111", exibirNaTela);
                }
                return resposta;
            }
            else
                throw new RequisicaoCancelarException("Ocorreu um erro ao Cancelar seu DFe, verifique o log para ter mais informações!");        
       }
    }
}
