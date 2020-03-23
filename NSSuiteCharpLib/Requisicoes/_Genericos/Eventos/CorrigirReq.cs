
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Eventos
{
    public abstract class CorrigirReq : Evento
    {
        public string tpAmb { get; set; }
        public string dhEvento { get; set; }
        public string nSeqEvento { get; set; }

       public abstract string AssinarXMLCorrecao(string conteudo, string cnpjEmitente);
       public abstract string EnviarCorrecao(string cnpjEmitente, bool a3);
       public abstract string EnviarCorrecaoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3);
       public abstract string GerarXMLCorrecao(string conteudo, string tpConteudo);
       protected virtual string ValidarCartaCorrecao(DownloadEventoReq downloadEventoReq, string cnpjEmitente, string caminho, bool exibirNaTela, bool a3)
        {
            string resposta = EnviarCorrecao(cnpjEmitente, a3);
            var conteudo = JsonConvert.DeserializeObject<CorrigirResp>(resposta);
            string status = conteudo.status;

            if (status.Equals("200"))
            {
                string cStat = conteudo.retEvento.cStat;
                if (cStat.Equals("135"))
                {
                    downloadEventoReq.EnviarDownloadEventoESalvar(caminho, "110110", exibirNaTela);
                }
                return resposta;
            }
            else
                throw new RequisicaoCorrecaoException("Ocorreu um erro ao Corrigir seu DFe, veja o retorno da API para mais informações");
        }

    }
}