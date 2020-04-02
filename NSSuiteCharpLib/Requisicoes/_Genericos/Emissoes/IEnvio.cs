using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static NSSuiteCSharpLib.Requisicoes._Genericos.Padroes.Requisicao;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IEnvio
    {
        IDownload GetObjectDownload(ConsStatusProcessamentoResp consultarResp, string tpDown);
        string EnviarEmissao(bool a3);
        string GerarXMLEnvio(string chave);
        //void EnviarEmissaoSincrona(string tpDown, string caminho, bool exibirNaTela, bool a3);
        EmitirResp EnviarEmissaoDocumento(Projeto projeto, string conteudo, string url, string tpConteudo);
        EmitirResp EnviarEmissaoDocumento(IEnvio envioReq, Projeto projeto, string cUF, string dhEmi,
            string serie, string nDF, string tpEmis, string cDF, string cnpjEmitente, string url);
        void RequisitarEmissaoSicrona(string tpDown, string caminho, bool exibirNaTela, bool a3);
    }
}
