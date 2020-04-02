using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Respostas.NFCe;
using System.Diagnostics;
using static NSSuiteCSharpLib.Requisicoes._Genericos.Padroes.Requisicao;

namespace NSSuiteCSharpLib.Requisicoes.NFCe
{
    public class DownloadReqNFCe : IDownload
    {
        public string tpDown { get; set; }
        public int tpAmb { get; set; }
        public string chNFe { get; set; }
        //Unico de NFCe
        public Impressao impressao { get; set; }

        public string EnviarDownload(string caminho, bool exibirNaTela)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.NFCeDownload, "DONWLOAD_NFCe");
        }
        public void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            string resposta = this.EnviarDownload(caminho, exibirNaTela);
            var downloadRespNFCe = JsonConvert.DeserializeObject<DownloadRespNFCe>(resposta);
            switch (downloadRespNFCe.status)
            {
                case "200":
                    string nomeArq = $"{chNFe}-{Projeto.NFCe}Proc";
                    string xml = downloadRespNFCe.nfeProc.xml;
                    Comuns.salvarXML(xml, caminho, nomeArq);

                    string pdf = downloadRespNFCe.pdf;
                    Comuns.salvarPDF(pdf, caminho, nomeArq);

                    if (exibirNaTela)
                        Process.Start($"{caminho + nomeArq}.pdf");
                    break;
                case "-2":
                    throw new RequisicaoDownloadException($"{downloadRespNFCe.motivo}, ele difere de X, P, XP ou PX");
                default:
                    throw new RequisicaoDownloadException(downloadRespNFCe.motivo);
            }
        }
    }
}