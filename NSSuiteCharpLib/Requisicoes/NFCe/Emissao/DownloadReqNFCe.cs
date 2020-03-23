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
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.NFCeDownload, "DOWNLOAD_NFCe");
        }

        public override string EnviarDownloadESalvar(string caminho, bool exibirNaTela)
        {
            return ValidarDownload(caminho, chNFe, exibirNaTela);
        }
        
        protected override string ValidarDownload(string caminho, string chave, bool exibirNaTela)
        {
            string resposta = EnviarDownload();
            var downloadResp = JsonConvert.DeserializeObject<DownloadRespNFCe>(resposta);

            if (downloadResp.status.Equals("100"))
                BaixarArquivos(downloadResp, CriarDiretorio(caminho), chave, exibirNaTela);
            else
                throw new RequisicaoDownloadException("Ocorreu um erro, veja o retorno da API para mais informações");

            return resposta;
        }
        private void BaixarArquivos(DownloadRespNFCe downloadRespNFCe, string caminho, string nome, bool exibirNaTela)
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