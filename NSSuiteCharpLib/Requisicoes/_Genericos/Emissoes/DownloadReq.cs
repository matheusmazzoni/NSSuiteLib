

using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
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
        public abstract void EnviarDownloadESalvar(string caminho, bool exibirNaTela);
        public virtual void TratamentoDownloadEmissao(string resposta, string caminho, string chave, bool exibirNaTela)
        {
            dynamic downloadResp = JsonConvert.DeserializeObject(resposta);
            switch (downloadResp.status)
            {
                case "200":
                    BaixarArquivos(downloadResp, CriarDiretorio(caminho), chave, exibirNaTela);
                    break;
                case "-2":
                    throw new RequisicaoDownloadException(downloadResp.motivo + ", ele difere de X, P, XP ou PX");
                default:
                    throw new RequisicaoDownloadException(downloadResp.motivo);
            }               
        }
        private void BaixarArquivos(dynamic downloadResp, string caminho, string nome, bool exibirNaTela)
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
        }
    }
}