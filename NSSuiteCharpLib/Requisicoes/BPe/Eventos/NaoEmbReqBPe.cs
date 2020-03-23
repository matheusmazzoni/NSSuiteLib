using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas.BPe.Eventos;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class NaoEmbReqBPe : Evento
    {
        public string tpAmb { get; set; }
        public string dhEvento { get; set; }
        public string nProt { get; set; }
        public string xJust { get; set; }
        public string chBPe { get; set; }

        public string EnviarNaoEmb()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.BPeNaoEmb, "NAO_EMB_BPe");
        }
        public string EnviarNaoEmbESalvar(string cnpjEmitente, string caminho)
        {
            string resposta = EnviarNaoEmb();
            var conteudo = JsonConvert.DeserializeObject<NaoEmbRespBPe>(resposta);
            string status = conteudo.status;

            if (status.Equals("200"))
            {
                string cStat = conteudo.retEvento.cStat;
                if (cStat.Equals("135"))
                {
                    string xml = conteudo.retEvento.xml;
                    Comuns.salvarXML(xml, caminho, "NaoEmbarque" + conteudo.retEvento.chBPe);
                }
            }
            else
                throw new System.Exception();
            return resposta;
        }
    }
}