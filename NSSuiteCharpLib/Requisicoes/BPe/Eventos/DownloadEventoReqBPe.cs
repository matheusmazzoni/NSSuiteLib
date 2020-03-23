﻿
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Eventos;

namespace NSSuiteCSharpLib.Requisicoes.BPe.Eventos
{
    public class DownloadEventoReqBPe : DownloadEventoReq
    {
        public string chBPe { get; set; }

        public override string EnviarDownloadEvento()
        {
            string conteudo = JsonConvert.SerializeObject(this);
            return RequisitarNaAPI(conteudo, Endpoints.BPeDownloadEvento, "DOWNLOAD_EVENTO_BPe");
        }

        public override void EnviarDownloadEventoESalvar(string caminho, string tpEvento, bool exibirNaTela)
        {
            ValidarDownloadEvento(caminho, tpEvento + chBPe, exibirNaTela);
        }
    }
}