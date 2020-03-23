using Newtonsoft.Json;
using NSSuiteCharpLib.Respostas.BPe.Eventos;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;

namespace NSSuiteCharpLib.Requisicoes.BPe.Eventos
{
    public class AlterarPoltronaReqBPe : Evento
    {
        public string chBPe { get; set; }
        public string nProt { get; set; }
        public string tpAmb { get; set; }
        public string dhEvento { get; set; }
        public string poltrona { get; set; }

        private string EnviarAlterarPoltrona()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.BPeCancelamento, "ALTERACAO_POLTRONA_BPe");
        }
        public string EnvairAllterarPoltronaESalvar(string caminho)
        {
            string resposta = EnviarAlterarPoltrona();
            var conteudo = JsonConvert.DeserializeObject<AlterarPoltronaResp>(resposta);
            string status = conteudo.status;

            if (status.Equals("200"))
            {
                string cStat = conteudo.retEvento.cStat;
                if (cStat.Equals("135"))
                {
                    string xml = conteudo.retEvento.xml;
                    Comuns.salvarXML(xml, caminho, "AlteracaoPoltrona" + conteudo.retEvento.chBPe);
                }
            }
            else
                throw new System.Exception();
            return resposta;
        }
    }
}
