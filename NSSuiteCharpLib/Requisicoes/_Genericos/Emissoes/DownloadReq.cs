

using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System;
using System.Diagnostics;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class DownloadReq : Emissao
    {
        public string tpDown { get; set; }
        public string tpAmb { get; set; }


        public abstract string EnviarDownload();

        public abstract string EnviarDownloadESalvar(string caminho, bool exibirNaTela);

        protected virtual string ValidarDownload(string caminho, string chave, bool exibirNaTela)
        {
            string resposta = EnviarDownload();
            var downloadResp = JsonConvert.DeserializeObject<DownloadResp>(resposta);
            string status = downloadResp.status;

            if (status.Equals("200"))            
                BaixarArquivos(downloadResp, CriarDiretorio(caminho), chave, exibirNaTela);
            else
                throw new Exception("Ocorreu um erro, veja o retorno da API para mais informações");

            return resposta;
        }
        private string BaixarArquivos(DownloadResp downloadResp, string caminho, string nome, bool exibirNaTela)
        {
            if (tpDown.ToUpper().Contains("X"))
                Comuns.salvarXML(downloadResp.xml, caminho, nome + "-procEven");

            if (tpDown.ToUpper().Contains("P"))
            {
                string pdf = downloadResp.pdf;
                Comuns.salvarPDF(pdf, caminho, nome + "-procEven");

                if (exibirNaTela)
                    Process.Start(caminho + nome + ".pdf");
            }
            return caminho;
        }
    }
}