using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace NSSuiteCSharpLib.Requisicoes._Genericos.Padroes
{
     public class Requisicao
     {
        public enum Projeto { BPe=63, CTe=57, CTeOS=67, MDFe=58, NFCe=65, NFe=55}
        private static string EnviaConteudoParaAPI(string conteudo, string url, string tpConteudo)
        {
            string retorno = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["X-AUTH-TOKEN"] = NSSuite.Token;
            if (tpConteudo.Equals("xml"))
                httpWebRequest.ContentType = "application/xml;charset=utf-8";
            else if (tpConteudo.Equals("json"))
                httpWebRequest.ContentType = "application/json;charset=utf-8";

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
                        retorno = streamReader.ReadToEnd();

                    switch (Convert.ToInt32(response.StatusCode))
                    {
                        case 401:
                            throw new ErroRequisicaoAPIException("Token não enviado ou inválido");
                        case 403:
                            throw new ErroRequisicaoAPIException("Token sem permissão");
                        case 404:
                            throw new ErroRequisicaoAPIException("Não encontrado, verifique o retorno para mais informações");
                        default:
                            break;
                    }
                }
            }
            return retorno;
        }
        public static string RequisitarNaAPI(string conteudo, string url, string nomeEvento, string tpConteudo = "json")
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
