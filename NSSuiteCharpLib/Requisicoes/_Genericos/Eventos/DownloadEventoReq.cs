
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System.Diagnostics;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Eventos
{
    public abstract class DownloadEventoReq : Evento
    {
        public string tpAmb { get; set; }
        public string tpDown { get; set; }
        public string tpEvento { get; set; }
        public string nSeqEvento { get; set; }

        public abstract string EnviarDownloadEvento();
        public abstract void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela);
        protected virtual string ValidarDownloadEvento(string caminho, string nome, bool exibirNaTela)
        {
            string resposta = EnviarDownloadEvento();
            var downloadResp = JsonConvert.DeserializeObject<DownloadResp>(resposta);

            if (downloadResp.status.Equals("200"))
                BaixarArquivos(downloadResp, CriarDiretorio(caminho), nome, exibirNaTela);
            else
                throw new RequisicaoDownloadEventoException("Ocorreu um erro, veja o retorno da API para mais informações");

            return resposta;
        }
        private void BaixarArquivos(DownloadResp downloadResp, string caminho, string nome, bool exibirNaTela)
        {
            if (tpDown.ToUpper().Contains("X"))
                Comuns.salvarXML(downloadResp.xml, caminho, nome + "-procEven");

            if (tpDown.ToUpper().Contains("P"))
            {
                Comuns.salvarPDF(downloadResp.pdf, caminho, nome + "-procEven");
                if (exibirNaTela)
                    Process.Start(caminho + nome + ".pdf");
            }
        }
    }
}