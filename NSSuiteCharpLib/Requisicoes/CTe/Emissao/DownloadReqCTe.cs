
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.CTe.Emissao
{
    public class DownloadReqCTe : TemplateDownloadReq
    {
        public string chCTe { get; set; }
        public string CNPJ { get; set; }

        public override string GetChave()
        {
            return chCTe;
        }
        public override Projeto GetProjeto()
        {
            return Projeto.CTe;
        }
        public override string EnviarDownload(string caminho, bool exibirNaTela)
        {
            string conteudo = JsonConvert.SerializeObject(this);
            string url = Endpoints.CTeDownload;
            string msgLog = "DONWLOAD_CTe";
            return RequisitarNaAPI(conteudo, url, msgLog);
        }

    }
}