using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NSSuiteCSharpLib.Requisicoes._Genericos.Padroes.Requisicao;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IDownload
    {
        string tpDown { get; set; }
        int tpAmb { get; set; }

        string EnviarDownload(string caminho, bool exibirNaTela);
        void EnviarDownloadESalvar(string caminho, bool exibirNaTela);
    }
}
