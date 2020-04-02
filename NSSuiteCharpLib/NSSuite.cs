using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using System.Windows;

namespace NSSuiteCSharpLib
{
    public class NSSuite
    {
        public static string Token { get; private set; }
        public static int TempoEspera { get; private set; } 
        public NSSuite(string token)
        {
            Token = token;
            TempoEspera = 500;
        }

        public void EmitirDocumentoSincrono(IEnvio emissaoReq, string tpDown, string caminho,
            bool exibirNaTela = false, bool a3 = false)
        {
            try
            {
                emissaoReq.RequisitarEmissaoSicrona(tpDown, caminho, exibirNaTela, a3);
            }
            catch(ErroRequisicaoAPIException ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao requisitar para API", MessageBoxButton.OK, MessageBoxImage.Error);
            }         
        }

        public string CancelarDocumentoESalvar(CancelarReq cancelarReq, DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela = false, bool a3 = false)
        {
            return cancelarReq.EnviarCancelamentoESalvar(downloadEventoReq, caminho, cnpjEmitente, exibirNaTela, a3);
        }

        public string CorrigirDocumentoESalvar(CorrigirReq corrigirReq, DownloadEventoReq downloadEventoReq, string caminho, string cnpjEmitente, bool exibirNaTela = false, bool a3 = false)
        {
            return corrigirReq.EnviarCorrecaoESalvar(downloadEventoReq, caminho, cnpjEmitente, exibirNaTela, a3);
        }

        //public string DownloadDocumento(DownloadReq DownloadReq)
        //{
        //    string urlDownload;

        //    switch (modelo)
        //    {
        //        case "63":
        //            {
        //                urlDownload = Endpoints.BPeDownload;
        //                break;
        //            }

        //        case "57":
        //        case "67":
        //            {
        //                urlDownload = Endpoints.CTeDownload;
        //                break;
        //            }

        //        case "58":
        //            {
        //                urlDownload = Endpoints.MDFeDownload;
        //                break;
        //            }

        //        case "65":
        //            {
        //                urlDownload = Endpoints.NFCeDownload;
        //                break;
        //            }

        //        case "55":
        //            {
        //                urlDownload = Endpoints.NFeDownload;
        //                break;
        //            }

        //        default:
        //            {
        //                throw new Exception("Não definido endpoint de download para o modelo " + modelo);
        //            }
        //    }

        //    string json = JsonConvert.SerializeObject(DownloadReq);

        //    Genericos.gravarLinhaLog(modelo, "[DOWNLOAD_DADOS]");
        //    Genericos.gravarLinhaLog(modelo, json);

        //    string resposta = enviaConteudoParaAPI(json, urlDownload, "json");

        //    string status;
        //    if (!modelo.Equals("65"))
        //    {
        //        DownloadResp DownloadResp = new DownloadResp();
        //        DownloadResp = JsonConvert.DeserializeObject<DownloadResp>(resposta);
        //        status = DownloadResp.status;
        //    }
        //    else
        //    {
        //        DownloadRespNFCe DownloadRespNFCe = new DownloadRespNFCe();
        //        DownloadRespNFCe = JsonConvert.DeserializeObject<DownloadRespNFCe>(resposta);
        //        status = DownloadRespNFCe.status;
        //    }

        //    // O retorno da API será gravado somente em caso de erro, 
        //    // para não gerar um log extenso com o PDF e XML
        //    if (!status.Equals("200") & !status.Equals("100"))
        //    {
        //        Genericos.gravarLinhaLog(modelo, "[DOWNLOAD_RESPOSTA]");
        //        Genericos.gravarLinhaLog(modelo, resposta);
        //    }
        //    else
        //    {
        //        Genericos.gravarLinhaLog(modelo, "[DOWNLOAD_STATUS]");
        //        Genericos.gravarLinhaLog(modelo, status);
        //    }

        //    return resposta;
        //}

        //public string ConsultarStatusProcessamentoDocumento(ConsStatusProcessamentoReq ConsStatusProcessamentoReq)
        //{
        //    string urlConsulta;

        //    switch (modelo)
        //    {
        //        case "63":
        //            {
        //                urlConsulta = Endpoints.BPeConsStatusProcessamento;
        //                break;
        //            }

        //        case "57":
        //        case "67":
        //            {
        //                urlConsulta = Endpoints.CTeConsStatusProcessamento;
        //                break;
        //            }

        //        case "58":
        //            {
        //                urlConsulta = Endpoints.MDFeConsStatusProcessamento;
        //                break;
        //            }

        //        case "55":
        //            {
        //                urlConsulta = Endpoints.NFeConsStatusProcessamento;
        //                break;
        //            }

        //        default:
        //            {
        //                throw new Exception("Não definido endpoint de consulta para o modelo " + modelo);
        //            }
        //    }

        //    string json = JsonConvert.SerializeObject(ConsStatusProcessamentoReq);

        //    Genericos.gravarLinhaLog(modelo, "[CONSULTA_DADOS]");
        //    Genericos.gravarLinhaLog(modelo, json);

        //    string resposta = enviaConteudoParaAPI(json, urlConsulta, "json");

        //    Genericos.gravarLinhaLog(modelo, "[CONSULTA_RESPOSTA]");
        //    Genericos.gravarLinhaLog(modelo, resposta);
        //    return resposta;
        //}

        //
        //        public static string inutilizarNumeracao(string modelo, InutilizarReq InutilizarReq, string cnpjEmitente, bool a3)
        //        {
        //            string urlInutilizacao;
        //            string nodo = "infInut";
        //
        //            switch (modelo)
        //            {
        //                case "57":
        //                case "67":
        //                    {
        //                        urlInutilizacao = Endpoints.CTeInutilizacao;
        //                        break;
        //                    }
        //
        //                case "65":
        //                    {
        //                        urlInutilizacao = Endpoints.NFCeInutilizacao;
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        urlInutilizacao = Endpoints.NFeInutilizacao;
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Não definido endpoint de inutilização para o modelo " + modelo);
        //                    }
        //            }
        //
        //            string conteudo = JsonConvert.SerializeObject(InutilizarReq);
        //
        //            if (a3)
        //            {
        //                string xml;
        //                try
        //                {
        //                    string respostaJSON = gerarXMLInutilizacao(modelo, conteudo, "json");
        //                    dynamic nodoJSON = JsonConvert.DeserializeObject(respostaJSON);
        //                    xml = nodoJSON.xml;
        //
        //                    X509Certificate2 cert = Genericos.buscaCertificado(cnpjEmitente.Trim());
        //                    if (cert == null)
        //                    {
        //                        MessageBox.Show("Certificado Digital não encontrado");
        //                        return null;
        //                    }
        //
        //                    conteudo = Genericos.assinaXML(xml.Trim(), nodo, cert);
        //
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                }
        //
        //            }
        //
        //            Genericos.gravarLinhaLog(modelo, "[INUTILIZACAO_DADOS]");
        //            Genericos.gravarLinhaLog(modelo, conteudo);
        //
        //            string resposta = enviaConteudoParaAPI(conteudo, urlInutilizacao, "json");
        //
        //            Genericos.gravarLinhaLog(modelo, "[INUTILIZACAO_RESPOSTA]");
        //            Genericos.gravarLinhaLog(modelo, resposta);
        //
        //            return resposta;
        //        }
        //
        //        public static string inutilizarNumeracaoESalvar(string modelo, InutilizarReq InutilizarReq, string caminho, string cnpjEmitente, bool a3 = false)
        //        {
        //            string resposta = inutilizarNumeracao(modelo, InutilizarReq, cnpjEmitente, a3);
        //            string status;
        //            string xml;
        //            string chave;
        //
        //            xml = null;
        //            chave = null;
        //
        //            switch (modelo)
        //            {
        //                case "57":
        //                case "67":
        //                    {
        //                        InutilizarRespCTe InutilizarRespCTe = new InutilizarRespCTe();
        //                        InutilizarRespCTe = JsonConvert.DeserializeObject<InutilizarRespCTe>(resposta);
        //                        status = InutilizarRespCTe.status;
        //                        if (status.Equals("200"))
        //                        {
        //                            string cStat = InutilizarRespCTe.retornoInutCTe.cstat;
        //                            if (cStat.Equals("102"))
        //                            {
        //                                xml = InutilizarRespCTe.retornoInutCTe.xmlInut;
        //                                chave = InutilizarRespCTe.retornoInutCTe.chave;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Ocorreu um erro ao inutilizar a numeração, veja o retorno da API para mais informações");
        //                        }
        //                        break;
        //                    }
        //
        //                case "65":
        //                    {
        //                        InutilizarRespNFCe InutilizarRespNFCe = new InutilizarRespNFCe();
        //                        InutilizarRespNFCe = JsonConvert.DeserializeObject<InutilizarRespNFCe>(resposta);
        //                        status = InutilizarRespNFCe.status;
        //                        if (status.Equals("102"))
        //                        {
        //                            string cStat = InutilizarRespNFCe.retInutNFe.cStat;
        //                            if (cStat.Equals("102"))
        //                            {
        //                                xml = InutilizarRespNFCe.retInutNFe.xml;
        //                                chave = InutilizarRespNFCe.retInutNFe.chave;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Ocorreu um erro ao inutilizar a numeração, veja o retorno da API para mais informações");
        //                        }
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        InutilizarRespNFe InutilizarRespNFe = new InutilizarRespNFe();
        //                        InutilizarRespNFe = JsonConvert.DeserializeObject<InutilizarRespNFe>(resposta);
        //                        status = InutilizarRespNFe.status;
        //                        if (status.Equals("200"))
        //                        {
        //                            string cStat = InutilizarRespNFe.retornoInutNFe.cStat;
        //                            if (cStat.Equals("102"))
        //                            {
        //                                xml = InutilizarRespNFe.retornoInutNFe.xmlInut;
        //                                chave = InutilizarRespNFe.retornoInutNFe.chave;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Ocorreu um erro ao inutilizar a numeração, veja o retorno da API para mais informações");
        //                        }
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Nao existe para este modelo inutilização " + modelo);
        //                    }
        //
        //            }
        //
        //            if (!string.IsNullOrEmpty(xml))
        //            {
        //                if (!Directory.Exists(caminho)) Directory.CreateDirectory(caminho);
        //                Genericos.salvarXML(xml, caminho, chave);
        //            }
        //
        //            return resposta;
        //        }
        //
        //        public static string consultarCadastroContribuinte(string modelo, ConsCadReq ConsCadReq)
        //        {
        //            string urlConsCad;
        //
        //            switch (modelo)
        //            {
        //                case "57":
        //                case "67":
        //                    {
        //                        urlConsCad = Endpoints.CTeConsCad;
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        urlConsCad = Endpoints.NFeConsCad;
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Não definido endpoint de consulta de cadastro para o modelo " + modelo);
        //                    }
        //            }
        //
        //            string json = JsonConvert.SerializeObject(ConsCadReq, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
        //            {
        //                NullValueHandling = NullValueHandling.Ignore
        //            });
        //
        //            Genericos.gravarLinhaLog(modelo, "[CONS_CAD_DADOS]");
        //            Genericos.gravarLinhaLog(modelo, json);
        //
        //            string resposta = enviaConteudoParaAPI(json, urlConsCad, "json");
        //
        //            Genericos.gravarLinhaLog(modelo, "[CONS_CAD_RESPOSTA]");
        //            Genericos.gravarLinhaLog(modelo, resposta);
        //
        //            return resposta;
        //        }
        //
        //        public static string consultarSituacaoDocumento(string modelo, ConsSitReq ConsSitReq)
        //        {
        //            string urlConsSit;
        //
        //            switch (modelo)
        //            {
        //                case "63":
        //                    {
        //                        urlConsSit = Endpoints.BPeConsSit;
        //                        break;
        //                    }
        //
        //                case "57":
        //                case "67":
        //                    {
        //                        urlConsSit = Endpoints.CTeConsSit;
        //                        break;
        //                    }
        //
        //                case "58":
        //                    {
        //                        urlConsSit = Endpoints.MDFeConsSit;
        //                        break;
        //                    }
        //
        //                case "65":
        //                    {
        //                        urlConsSit = Endpoints.NFCeConsSit;
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        urlConsSit = Endpoints.NFeConsSit;
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Não definido endpoint de consulta de situação para o modelo " + modelo);
        //                    }
        //            }
        //
        //            string json = JsonConvert.SerializeObject(ConsSitReq);
        //
        //            Genericos.gravarLinhaLog(modelo, "[CONS_SIT_DADOS]");
        //            Genericos.gravarLinhaLog(modelo, json);
        //
        //            string resposta = enviaConteudoParaAPI(json, urlConsSit, "json");
        //
        //            Genericos.gravarLinhaLog(modelo, "[CONS_SIT_RESPOSTA]");
        //            Genericos.gravarLinhaLog(modelo, resposta);
        //
        //            return resposta;
        //        }
        //
        //        public static string listarNSNRecs(string modelo, ListarNSNRecReq ListarNSNRecReq)
        //        {
        //            string urlListarNSNRecs;
        //
        //            switch (modelo)
        //            {
        //                case "57":
        //                case "67":
        //                    {
        //                        urlListarNSNRecs = Endpoints.CTeListarNSNRecs;
        //                        break;
        //                    }
        //
        //                case "58":
        //                    {
        //                        urlListarNSNRecs = Endpoints.MDFeListarNSNRecs;
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        urlListarNSNRecs = Endpoints.NFeListarNSNRecs;
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Não definido endpoint de listagem de nsNRec para o modelo " + modelo);
        //                    }
        //            }
        //
        //            string json = JsonConvert.SerializeObject(ListarNSNRecReq);
        //
        //            Genericos.gravarLinhaLog(modelo, "[LISTAR_NSNRECS_DADOS]");
        //            Genericos.gravarLinhaLog(modelo, json);
        //
        //            string resposta = enviaConteudoParaAPI(json, urlListarNSNRecs, "json");
        //
        //            Genericos.gravarLinhaLog(modelo, "[LISTAR_NSNRECS_RESPOSTA]");
        //            Genericos.gravarLinhaLog(modelo, resposta);
        //
        //            return resposta;
        //        }
        //
        //        public static string enviarEmailDocumento(string modelo, EnviarEmailReq EnviarEmailReq)
        //        {
        //            string urlEnviarEmail;
        //
        //            switch (modelo)
        //            {
        //                case "65":
        //                    {
        //                        urlEnviarEmail = Endpoints.NFCeEnvioEmail;
        //                        break;
        //                    }
        //
        //                case "55":
        //                    {
        //                        urlEnviarEmail = Endpoints.NFeEnvioEmail;
        //                        break;
        //                    }
        //
        //                default:
        //                    {
        //                        throw new Exception("Não definido endpoint de envio de e-mail para o modelo " + modelo);
        //                    }
        //            }
        //
        //            string json = JsonConvert.SerializeObject(EnviarEmailReq);
        //
        //            Genericos.gravarLinhaLog(modelo, "[ENVIAR_EMAIL_DADOS]");
        //            Genericos.gravarLinhaLog(modelo, json);
        //
        //            string resposta = enviaConteudoParaAPI(json, urlEnviarEmail, "json");
        //
        //            Genericos.gravarLinhaLog(modelo, "[ENVIAR_EMAIL_RESPOSTA]");
        //            Genericos.gravarLinhaLog(modelo, resposta);
        //
        //            return resposta;
        //        }
    }
}
