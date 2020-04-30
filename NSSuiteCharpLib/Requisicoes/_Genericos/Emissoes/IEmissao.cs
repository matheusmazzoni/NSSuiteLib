using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IEmissao
    {
        string EnviarEmissao(bool a3);
        string GerarXMLEnvio(string chave);
        void RequisitarEmissaoSicrona(string tpDown, string caminho, bool exibirNaTela, bool a3);
    }
}
