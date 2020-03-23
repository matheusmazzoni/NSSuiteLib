
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;
using NSSuiteCSharpLib.Respostas.NFCe;
using System;
using System.Diagnostics;
using System.IO;

namespace NSSuiteCSharpLib.Requisicoes.NFCe
{
    public class DownloadEventoReqNFCe : DownloadEventoReq
    {
        public string chNFe { get; set; }
        public Impressao impressao { get; set; }

        public override string EnviarDownloadEvento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.NFCeDownload, "DOWNLOAD_EVENTO_NFCe");
        }
        public override void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela)
        {
            ValidarDownloadEvento(caminho, tpEvento + chNFe, exibirNaTela);
        }
        protected override string ValidarDownloadEvento(string caminho, string chave, bool exibirNaTela)
        {
            string resposta = EnviarDownloadEvento();
            var downloadResp = JsonConvert.DeserializeObject<DownloadRespNFCe>(resposta);

            if (downloadResp.status.Equals("100"))
                BaixarArquivos(downloadResp, CriarDiretorio(caminho), chave, exibirNaTela);
            else
                throw new RequisicaoDownloadEventoException("Ocorreu um erro, veja o retorno da API para mais informações");

            return resposta;
        }
        private void BaixarArquivos(DownloadRespNFCe downloadResp, string caminho, string nome, bool exibirNaTela)
        {
            string xml = downloadResp.nfeProc.xml;
            Comuns.salvarXML(xml, caminho, nome + "-procEven");

            string pdf = downloadResp.pdfCancelamento;
            Comuns.salvarPDF(pdf, caminho, nome + "-procEven");

            if (exibirNaTela)
                Process.Start(caminho + nome + "-procEven.pdf");
        }
    }
}