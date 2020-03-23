using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IEnvioReq 
    {
        string AssinarXMLEmissao(string conteudo, string cnpjEmitente);
        string EnviarEmissao(bool a3);
        string GerarXMLCorrecao(string conteudo, string tpConteudo);
        string EnviarEmissaoSincrona(string tpDown, string caminho, bool exibirNaTela, bool a3);
    }
}
