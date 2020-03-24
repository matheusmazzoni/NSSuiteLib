
using Newtonsoft.Json;
using NSSuiteCSharpLib;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas.NFCe;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Padroes
{
     public class Requisicao
    {
        public enum Projeto { BPe=63, CTe=57, CTeOS=67, MDFe=58, NFCe=65, NFe=55}
        private int GerarDigitoVerificador(string chave)
        {
            int soma = 0; 
            int restoDivisao = -1; 
            int digitoVerificador = -1;  
            int pesoMultiplicacao = 2; 

            for (int i = chave.Length - 1; i != -1; i--)
            {
                int ch = Convert.ToInt32(chave[i].ToString());
                soma += ch * pesoMultiplicacao;

                if (pesoMultiplicacao < 9)
                    pesoMultiplicacao += 1;
                else
                    pesoMultiplicacao = 2;
            }
            restoDivisao = soma % 11;        
            if (restoDivisao == 0 || restoDivisao == 1)
                digitoVerificador = 0;
            else
                digitoVerificador = 11 - restoDivisao;

            return digitoVerificador;
        }
        protected string GerarChaveDocumento(int projeto, string versao, string cUF, string dhEmi,
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente,
            string tpEvento = "", string nSeqEvento = "")
        {
            for (int i = serie.Length; i < 3; i++)
                serie = "0" + serie;
            for (int i = nDF.Length; i < 9; i++)
                serie = "0" + serie;
            string[] auxAAMM = dhEmi.Split('T') ;
            DateTime dateTime = DateTime.Parse(auxAAMM[0]);
            string aamm = dateTime.ToString("yyMM");
            string chave43 = cUF + aamm + cnpjEmitente + projeto.ToString() + serie + nDF + tpEmis + cDF;
            string chave = tpEvento + chave43 + GerarDigitoVerificador(chave43) + nSeqEvento;
            return chave;
        }
        protected XmlDocument GerarXMLDocumento<T>(T ObjectXML)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectXML.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, ObjectXML);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc;
            }
        }

        protected string CriarDiretorio(string caminho)
        {
            try
            {
                if (!Directory.Exists(caminho)) Directory.CreateDirectory(caminho);
                if (!caminho.EndsWith(@"\")) caminho += @"\";
                return caminho;
            }
            catch (IOException ex)
            {
                Comuns.gravarLinhaLog("[CRIAR_DIRETORIO]" + caminho);
                Comuns.gravarLinhaLog(ex.Message);
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public X509Certificate2 BuscaCertificado(String cnpj)
        {
            X509Certificate2Collection lcerts;
            X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            lStore.Open(OpenFlags.ReadOnly);

            lcerts = lStore.Certificates;
            X509Certificate2 cert = null;
            foreach (X509Certificate2 elemento in lcerts)
            {
                if (elemento.Subject.Contains(cnpj))
                {
                    cert = elemento;
                    lStore.Close();
                    return cert;
                }
            }
            lStore.Close();
            return cert;
        }
        public string AssinaXML(string XMLString, string RefUri, X509Certificate2 X509Cert)
        {
            XmlDocument XMLDoc;
            try
            {

                string _xnome = "";
                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count == 0)
                {
                    throw new Exception("Problemas no certificado digital");
                }
                else
                {
                    _X509Cert = collection1[0];
                    string x;
                    x = _X509Cert.GetKeyAlgorithm().ToString();
                    XmlDocument doc = new XmlDocument();
                    doc.PreserveWhitespace = false;

                    try
                    {
                        doc.LoadXml(XMLString);
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            throw new Exception("A tag de assinatura " + RefUri.Trim() + " inexiste");
                        }
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                throw new Exception("A tag de assinatura " + RefUri.Trim() + " não é unica");
                            }
                            else
                            {
                                try
                                {

                                    SignedXml signedXml = new SignedXml(doc);

                                    signedXml.SigningKey = _X509Cert.PrivateKey;

                                    Reference reference = new Reference();

                                    XmlAttributeCollection _Uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                                    foreach (XmlAttribute _atributo in _Uri)
                                    {
                                        if (_atributo.Name == "Id")
                                        {
                                            reference.Uri = "#" + _atributo.InnerText;
                                        }
                                    }

                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    signedXml.AddReference(reference);

                                    KeyInfo keyInfo = new KeyInfo();

                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                    XMLDoc = new XmlDocument();
                                    XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = doc;
                                    return XMLDoc.OuterXml;
                                }
                                catch (Exception caught)
                                {
                                    throw new Exception("Erro: Ao assinar o documento - " + caught.Message);
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        throw new Exception("Erro: XML mal formado - " + caught.Message);
                    }
                }
            }
            catch (Exception caught)
            {
                throw new Exception("Erro: Problema ao acessar o certificado digital" + caught.Message);
            }
        }
        public virtual string AssinarXMLDocumento(string xml, string cnpjEmitente, string nodo)
        {
            X509Certificate2 cert = BuscaCertificado(cnpjEmitente.Trim());
            if (cert.Equals(null))
            {
                Comuns.gravarLinhaLog("Certificado Digital não encontrado");
                throw new Exception("Certificado Digital não encontrado");
            }

            return AssinaXML(xml.Trim(), nodo, cert);
        }

        private string EnviaConteudoParaAPI(string conteudo, string url, string tpConteudo)
        {
            string retorno = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["X-AUTH-TOKEN"] = NSSuite.Token;

            if (tpConteudo == "txt")
            {
                httpWebRequest.ContentType = "text/plain;charset=utf-8";
            }
            else if (tpConteudo == "xml")
            {
                httpWebRequest.ContentType = "application/xml;charset=utf-8";
            }
            else
            {
                httpWebRequest.ContentType = "application/json;charset=utf-8";
            }

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(conteudo);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    retorno = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;

                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        retorno = streamReader.ReadToEnd();
                    }

                    switch (Convert.ToInt32(response.StatusCode))
                    {
                        case 401:
                            {
                                MessageBox.Show("Token não enviado ou inválido");
                                break;
                            }

                        case 403:
                            {
                                MessageBox.Show("Token sem permissão");
                                break;
                            }

                        case 404:
                            {
                                MessageBox.Show("Não encontrado, verifique o retorno para mais informações");
                                break;
                            }
                        default:
                                break;
                    }
                }
            }
            return retorno;
        }
        protected virtual string RequisitarNaAPI(string conteudo, string url, string nomeEvento, string tpConteudo = "json")
        {
            Comuns.gravarLinhaLog("[" + nomeEvento.ToUpper() +"_DADOS]");
            Comuns.gravarLinhaLog(conteudo);

            string resposta = EnviaConteudoParaAPI(conteudo, url, tpConteudo);

            Comuns.gravarLinhaLog("[" + nomeEvento.ToUpper() + "_RESPOSTA]");
            Comuns.gravarLinhaLog(resposta);

            return resposta;
        }
    }
}
