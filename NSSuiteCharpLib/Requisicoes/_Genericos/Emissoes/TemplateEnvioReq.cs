using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class TemplateEnvioReq : EmissaoCommuns, IEmissao
    {
        protected abstract IDownload GetObjectDownload(ConsStatusProcessamentoResp consultarResp, string tpDown);
        protected abstract IConsStatusProcessamento GetObjectConsStatusProcessamento(string nsNRec);
        
        // Implementações da interface
        public abstract string EnviarEmissao(bool a3);
        public abstract string GerarXMLEnvio(string chave);
        public void RequisitarEmissaoSicrona(string tpDown, string caminho, bool exibirNaTela, bool a3)
        {   
            var nsNRec = this.EnviarEmissao(a3);       
            var consultaReq = this.GetObjectConsStatusProcessamento(nsNRec);
            var consultaResp = consultaReq.EnviarConsultaStatusProcesamento();
            var downloadReq = this.GetObjectDownload(consultaResp, tpDown);
            downloadReq.EnviarDownloadESalvar(caminho, exibirNaTela);
        }


    }
}
