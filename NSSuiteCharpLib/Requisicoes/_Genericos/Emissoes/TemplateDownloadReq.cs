using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System.Diagnostics;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class TemplateDownloadReq : Requisicao, IDownload
    {
        [JsonProperty("tpDown")]
        public string TipoDeDownload { get; set; }

        [JsonProperty("tpAmb")]
        public int TipoDeAmbiente { get; set; }

        public abstract string GetChave();
        public abstract Projeto GetProjeto();
        public abstract string EnviarDownload(string caminho, bool exibirNaTela);
        public void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            string resposta = this.EnviarDownload(caminho, exibirNaTela);         
            var downloadResp = JsonConvert.DeserializeObject<DownloadResp>(resposta);
            switch (downloadResp.status)
            {
                case "200":
                    caminho = Comuns.CriarDiretorio(caminho);
                    string nomeArq = $"{this.GetChave()}-{this.GetProjeto()}Proc";
                    if (TipoDeDownload.ToUpper().Contains("X"))
                        Comuns.salvarXML(downloadResp.xml, caminho, nomeArq);

                    if (TipoDeDownload.ToUpper().Contains("P"))
                    {
                        string pdf = downloadResp.pdf;
                        Comuns.salvarPDF(pdf, caminho, nomeArq);

                        if (exibirNaTela)
                            Process.Start($"{caminho + nomeArq}.pdf");
                    }
                    break;
                case "-2":
                    throw new RequisicaoDownloadException($"{downloadResp.motivo}, ele difere de X, P, XP ou PX");
                default:
                    throw new RequisicaoDownloadException(downloadResp.motivo);
            }               
        }     
    }
}