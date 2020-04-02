using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using static NSSuiteCSharpLib.Requisicoes._Genericos.Padroes.Requisicao;

namespace NSSuiteCSharpLib.Genericos
{
    public static class Comuns
    {
        private static int GerarDigitoVerificador(string chave)
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
        public static string GerarChaveDocumento(Projeto projeto, string cUF, string dhEmi,
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente,
            string tpEvento = "", string nSeqEvento = "")
        {
            for (int i = serie.Length; i < 3; i++)
                serie = "0" + serie;
            for (int i = nDF.Length; i < 9; i++)
                serie = "0" + serie;
            string[] auxAAMM = dhEmi.Split('T');
            DateTime dateTime = DateTime.Parse(auxAAMM[0]);
            string aamm = dateTime.ToString("yyMM");
            string chave43 = cUF + aamm + cnpjEmitente + ((int)projeto).ToString() + serie + nDF + tpEmis + cDF;
            string chave = tpEvento + chave43 + GerarDigitoVerificador(chave43) + nSeqEvento;
            return chave;
        }
        public static string GerarXMLDocumento<T>(T ObjectXML)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectXML.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, ObjectXML);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xmlDoc.WriteTo(xw);
                return sw.ToString();
            }
        }
        public static string CriarDiretorio(string caminho)
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
        private static X509Certificate2 BuscaCertificado(string cnpj)
        {
            X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            lStore.Open(OpenFlags.ReadOnly);

            var lcerts = lStore.Certificates;
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
            if (cert.Equals(null))
                throw new Exception("Certificado Digital não encontrado");
            return cert;
        }
        private static string AssinaXML(string XMLString, string RefUri, X509Certificate2 X509Cert)
        {
            XmlDocument XMLDoc;
            try
            {
                string _xnome = string.Empty;
                if (X509Cert != null)
                    _xnome = X509Cert.Subject.ToString();

                var _X509Cert = new X509Certificate2();
                var store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var collection = store.Certificates;
                var collection1 = collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count != 0)
                {
                    try
                    {
                        _X509Cert = collection1[0];
                        string x;
                        x = _X509Cert.GetKeyAlgorithm().ToString();
                        var doc = new XmlDocument();
                        doc.PreserveWhitespace = false;
                        doc.LoadXml(XMLString);
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri != 0)
                        {
                            if (qtdeRefUri <= 1)
                            {
                                try
                                {
                                    var signedXml = new SignedXml(doc);
                                    signedXml.SigningKey = _X509Cert.PrivateKey;
                                    var reference = new Reference();

                                    var _Uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                                    foreach (XmlAttribute _atributo in _Uri)
                                    {
                                        if (_atributo.Name == "Id")
                                            reference.Uri = "#" + _atributo.InnerText;
                                    }

                                    var env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    var c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    signedXml.AddReference(reference);

                                    var keyInfo = new KeyInfo();

                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    var xmlDigitalSignature = signedXml.GetXml();

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
                            else
                                throw new Exception("A tag de assinatura " + RefUri.Trim() + " não é unica");
                        }
                        else
                            throw new Exception("A tag de assinatura " + RefUri.Trim() + " inexiste");
                    }
                    catch (Exception caught)
                    {
                        throw new Exception("Erro: XML mal formado - " + caught.Message);
                    }
                }      
                else
                    throw new Exception("Problemas no certificado digital");
            }
            catch (Exception caught)
            {
                throw new Exception("Erro: Problema ao acessar o certificado digital" + caught.Message);
            }
        }
        public static string AssinarXMLDocumento(string xml, string cnpjEmitente, string nodo)
        {
            X509Certificate2 cert = BuscaCertificado(cnpjEmitente.Trim());
            return AssinaXML(xml.Trim(), nodo, cert);
        }
        public static void salvarXML(string xml, string caminho, string nome)
        {
            try
            {
                string localParaSalvar = $"{caminho + nome}.xml";
                string ConteudoSalvar = xml.Replace(@"\""", "");
                File.WriteAllText(localParaSalvar, ConteudoSalvar);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show("Seu documento foi autorizado com sucesso, " +
                    $"porem não pode ser salvo em {caminho}. Motivo {ex.Message}");
            }
        }
        public static void salvarPDF(string pdf, string caminho, string nome)
        {
            string localParaSalvar = $"{caminho + nome}.pdf";
            byte[] bytes = Convert.FromBase64String(pdf);
            if (File.Exists(localParaSalvar))
                File.Delete(localParaSalvar);
            using (BinaryWriter writer = new BinaryWriter(new FileStream(localParaSalvar, FileMode.CreateNew))) 
                writer.Write(bytes, 0, bytes.Length);       
        }
        public static void gravarLinhaLog(string conteudo)
        {
            string caminho = @".\log\";

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);
            string data = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff");
            string nomeArq = DateTime.Now.ToShortDateString().Replace("/", "");

            using (StreamWriter outputFile = new StreamWriter($"{caminho + nomeArq}.txt", true))
                outputFile.WriteLine(data +" - " + conteudo);       
        }

    }
}