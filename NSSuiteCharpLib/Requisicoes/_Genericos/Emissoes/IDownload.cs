
using Newtonsoft.Json;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IDownload
    {
        string TipoDeDownload { get; set; }
        int TipoDeAmbiente { get; set; }

        string EnviarDownload(string caminho, bool exibirNaTela);
        void EnviarDownloadESalvar(string caminho, bool exibirNaTela);
    }
}
