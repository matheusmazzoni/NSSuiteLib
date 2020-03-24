using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Respostas.NFCe;
using System.Diagnostics;

namespace NSSuiteCSharpLib.Requisicoes.NFCe
{
    public class DownloadReqNFCe : DownloadReq
    { 
        public string chNFe { get; set; }
        public Impressao impressao { get; set; }

        public override string EnviarDownload()
        {
            return DownlaodEmissao(Projeto.NFCe, JsonConvert.SerializeObject(this), Endpoints.NFCeDownload);
        }
        public override void EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            DownlaodEmissaoComTratamento(this, caminho, chNFe, exibirNaTela);
        }
        public override void TratamentoDownloadEmissao(string resposta, string caminho, string chave, bool exibirNaTela)
        {
            dynamic downloadResp = JsonConvert.DeserializeObject(resposta);
            switch (downloadResp.status)
            {
                case "100":
                    BaixarArquivos(downloadResp, CriarDiretorio(caminho), chave, exibirNaTela);
                    break;
                case "-2":
                    throw new RequisicaoDownloadException(downloadResp.motivo + ", ele difere de X, P, XP ou PX");
                default:
                    throw new RequisicaoDownloadException(downloadResp.motivo);
            }
        }
        private void BaixarArquivos(dynamic downloadRespNFCe, string caminho, string nome, bool exibirNaTela)
        {
            string xml = downloadRespNFCe.nfeProc.xml;
            Comuns.salvarXML(xml, caminho, nome);

            string pdf = downloadRespNFCe.pdf;
            Comuns.salvarPDF(pdf, caminho, nome);

            if (exibirNaTela)
                Process.Start(caminho + nome + ".pdf");
        }
    }
}