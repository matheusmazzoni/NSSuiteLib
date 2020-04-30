using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas._Genéricas.Emissoes;


namespace NSSuiteCSharpLib.Requisicoes._Genericos.Padroes
{
    public class EmissaoCommuns : Requisicao
    {
        protected IEmitirResp EnviarEmissaoDocumento(Projeto projeto, string conteudo, string url, string tpConteudo)
        {
            string resposta = RequisitarNaAPI(conteudo, url, $"ENVIO_{projeto}", tpConteudo);
            if (Projeto.NFCe.Equals(projeto))
                return JsonConvert.DeserializeObject<EmitirRespNFCe>(resposta);
            return JsonConvert.DeserializeObject<EmitirResp>(resposta);
        }
        protected IEmitirResp EnviarEmissaoDocumentoComAssinatura(IEmissao envioReq, Projeto projeto, string cUF, string dhEmi,
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente, string nodo, string url)
        {
            string chave = Comuns.GerarChaveDocumento(projeto, cUF, dhEmi, serie, nDF, tpEmis, cDF, cnpjEmitente);
            string xml = envioReq.GerarXMLEnvio(chave).Trim().Replace(@"\""", "");
            string xmlAssinado = Comuns.AssinarXMLDocumento(xml, cnpjEmitente, nodo);
            return EnviarEmissaoDocumento(projeto, xmlAssinado, url, "xml");
        }
    }
}
