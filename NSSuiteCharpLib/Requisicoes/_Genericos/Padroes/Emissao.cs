
using Newtonsoft.Json;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes.BPe;
using System;
using System.Threading;
using System.Windows;
using System.Xml;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Padroes
{
    public class Emissao : Requisicao
    {    
        protected string DownlaodEmissao(Projeto projeto, string conteudo, string url)
        {
            return RequisitarNaAPI(conteudo, url, "DONLOAD_"+ projeto.ToString());
        }
        protected void DownlaodEmissaoComTratamento(DownloadReq downloadReq, string caminho, string chave, bool exibirNaTela)
        {
            string resposta = downloadReq.EnviarDownload();
            downloadReq.TratamentoDownloadEmissao(resposta, caminho, chave, exibirNaTela);
        }

        /*Realiza a Consulta de Status de Processamento de um DF-e*/
        protected string ConsultaStatusProcessamentoEmissao()
        {
            return null;
        }
        protected string ConsultaStatusProcessamentoEmissaoComTratamento(ConsStatusProcessamentoReq consultarReq)
        {
            string resposta = consultarReq.EnviarConsultaStatusProcesamento();
            consultarReq.TratamentoConsultaEmissao(consultarReq, resposta);
            return null;
        }

        /*Emissao com e Sem assinatura*/
        private string AssinarXMLEmissao(string xml, string cnpjEmitente, string nodo)
        {
            return AssinarXMLDocumento(xml, cnpjEmitente, nodo);
        }
        private string GerarXMLEmissao(string projeto, IEnvioReq envioReq, string chave)
        {
            XmlDocument xmlDoc = envioReq.GerarXMLEnvio();
            XmlElement nodoPrincipal = xmlDoc.SelectSingleNode(projeto) as XmlElement;
            nodoPrincipal.RemoveAllAttributes();
            XmlElement nodoIndDoc = xmlDoc.SelectSingleNode(projeto+"/inf"+projeto) as XmlElement;
            nodoIndDoc.SetAttribute("Id", projeto + chave);
            return xmlDoc.InnerXml.Trim().Replace(@"\""", "");
        }
        private string GerarChaveEmissao(Projeto projeto, string versao, string cUF, string dhEmi, 
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente)
        {
            return GerarChaveDocumento((int) projeto, versao, cUF, dhEmi, serie, nDF, tpEmis, cDF, cnpjEmitente);
        }
        protected string EnviarEmissao(Projeto projeto, string conteudo, string url, string tpConteudo = "json")
        {
            return RequisitarNaAPI(conteudo, url, "ENVIO_" + projeto.ToString(), tpConteudo);
        }
        protected string EnviarEmissaoComAssinatura(IEnvioReq envioReq, Projeto projeto, string versao, string cUF,
            string dhEmi, string serie, string nDF, string tpEmis, string cDF, String cnpjEmitente, string url)
        {
            string chave = GerarChaveEmissao(projeto, versao, cUF, dhEmi, serie, nDF, tpEmis, cDF, cnpjEmitente);
            string xml = GerarXMLEmissao(projeto.ToString(), envioReq, chave);
            string xmlAssinado = AssinarXMLEmissao(xml, cnpjEmitente, "inf" + projeto.ToString());
            string resposta = EnviarEmissao(projeto, xmlAssinado, url, "xml");
            return resposta;
        }

        private dynamic GetJsonConsultaStatusProcessamento(Projeto projeto, string cnpjEmitente, string nsNRec, string tpAmb)
        {
            dynamic consultarReq = null;
            switch (projeto)
            {
                case Projeto.BPe:
                    consultarReq = new ConsStatusProcessamentoReqBPe();
                    break;
                case Projeto.CTe:
                    //consultarReq = new ConsStatusProcessamentoReqCTe()
                    //break;
                case Projeto.MDFe:
                    //consultarReq = new ConsStatusProcessamentoReqMDFe();
                    //break;
                case Projeto.NFe:
                    //consultarReq = new ConsStatusProcessamentoReqNFe();
                    break;
            }
            consultarReq.CNPJ = cnpjEmitente;
            consultarReq.nsNRec = nsNRec;
            consultarReq.tpAmb = tpAmb;
            return consultarReq;
        }
        private dynamic GetJsonDownload(Projeto projeto, dynamic consultarResp, string tpAmb, string tpDown)
        {
            dynamic downloadReq = null;
            switch (projeto)
            {
                case Projeto.BPe:
                    downloadReq = new DownloadReqBPe()
                    {
                        chBPe = consultarResp.chBPe,
                        tpAmb = tpAmb,
                        tpDown = tpDown
                    };
                    break;
                case Projeto.CTe:
                    // downloadReq = new DownloadReqCTe()
                    //break;
                case Projeto.MDFe:
                //downloadReq = new DownloadReqMDFe();
                //break;
                case Projeto.NFCe:
                    //downloadReq = new DownloadReqNFe();
                    break;
                case Projeto.NFe:
                    //downloadReq = new DownloadReqNFe();
                    break;
            }
            return downloadReq;
        }
        protected void RequisitarEmissaoSicrona(IEnvioReq envioReq, Projeto projeto, string cnpjEmintente, string tpAmb, string tpDown, string caminho, bool exibirNaTela, bool a3)
        {
            dynamic emitirResp = envioReq.EnviarEmissao(a3);

            Thread.Sleep(NSSuite.TempoEspera);

            dynamic consultarReq = GetJsonConsultaStatusProcessamento(projeto, cnpjEmintente, emitirResp.nsNRec, tpAmb);
            string resposta = consultarReq.EnviarConsultaStatusProcesamento();
            dynamic consultarResp = JsonConvert.DeserializeObject(resposta);

            dynamic downloadReq = GetJsonDownload(projeto, consultarResp, tpAmb, tpDown);
            downloadReq.EnviarDownloadESalvar(caminho, exibirNaTela);
            MessageBox.Show("Emissão Sincrona Feita com Sucesso!!");
        }
    } 
}
