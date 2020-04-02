
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System.Collections.Generic;

namespace NSSuiteCSharpLib.Requisicoes.CTe
{
    public class InfCorrecao
    {
        public string grupoAlterado { get; set; }
        public string campoAlterado { get; set; }
        public string valorAlterado { get; set; }
        public string nroItemAlterado { get; set; }
    }
    public class CorrigirReqCTe : CorrigirReq
    {
        public string chCTe { get; set; }
        public List<InfCorrecao> infCorrecao { get; set; }


        public override string EnviarCorrecao(string cnpjEmitente, bool a3)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            if (a3)
                AssinarXMLCorrecao(conteudo, cnpjEmitente);
            return Requisicao.RequisitarNaAPI(conteudo, Endpoints.CTeCCe, "CCE_CTe");
        }

        public override string EnviarCorrecaoESalvar(DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela, bool a3)
        {
            throw new System.NotImplementedException();
        }

        public override string AssinarXMLCorrecao(string conteudo, string cnpjEmitente)
        {
            throw new System.NotImplementedException();
        }

        public override string GerarXMLCorrecao(string conteudo, string tpConteudo)
        {
            throw new System.NotImplementedException();
        }
    }


}