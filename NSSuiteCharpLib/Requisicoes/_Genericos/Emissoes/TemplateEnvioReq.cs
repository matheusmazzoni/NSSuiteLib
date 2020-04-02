using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using static NSSuiteCSharpLib.Requisicoes._Genericos.Padroes.Requisicao;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class TemplateEnvioReq : IEnvio
    {
        public abstract string EnviarEmissao(bool a3);
        public abstract string GerarXMLEnvio(string chave);
        public abstract IDownload GetObjectDownload(ConsStatusProcessamentoResp consultarResp, string tpDown);
        protected abstract IConsStatusProcessamento GetObjectConsStatusProcessamento(string nsNRec);

        // Emissão Com e Sem Assinatura de XML
        public EmitirResp EnviarEmissaoDocumento(Projeto projeto, string conteudo, string url, string tpConteudo)
        {
            string resposta = Requisicao.RequisitarNaAPI(conteudo, url, $"ENVIO_{projeto}", tpConteudo);
            return JsonConvert.DeserializeObject<EmitirResp>(resposta);
        }
        public EmitirResp EnviarEmissaoDocumento(IEnvio envioReq, Projeto projeto, string cUF, string dhEmi,
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente, string url)
        {
            string chave = Comuns.GerarChaveDocumento(projeto, cUF, dhEmi, serie, nDF, tpEmis, cDF, cnpjEmitente);
            string xml = envioReq.GerarXMLEnvio(chave).Trim().Replace(@"\""", "");
            string nodo = $"inf{projeto}";
            string xmlAssinado = Comuns.AssinarXMLDocumento(xml, cnpjEmitente, nodo);
            return EnviarEmissaoDocumento(projeto, xmlAssinado, url, "xml");
        }
        public void RequisitarEmissaoSicrona(string tpDown, string caminho, bool exibirNaTela, bool a3)
        {   
            var nsNRec = this.EnviarEmissao(a3);       
            var consultaReq = this.GetObjectConsStatusProcessamento(nsNRec);
            var consultaResp = consultaReq.EnviarConsultaStatusProcesamento();
            var downloadReq = this.GetObjectDownload(consultaResp, tpDown);
            downloadReq.EnviarDownloadESalvar(caminho, exibirNaTela);
        }

    }
}
