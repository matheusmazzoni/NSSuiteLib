using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IEnvioReq 
    {
        dynamic EnviarEmissao(bool a3);
        XmlDocument GerarXMLEnvio();
        void EnviarEmissaoSincrona(string tpDown, string caminho, bool exibirNaTela, bool a3);
        dynamic TratamentoEnviarEmissao(string resposta);
    }
}
