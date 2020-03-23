
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes.BPe;
using NSSuiteCSharpLib.Respostas._Genericos;
using NSSuiteCSharpLib.Respostas.BPe;
using NSSuiteCSharpLib.Respostas.BPe.Emissoes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Padroes
{
    public class Emissao : Requisicao
    {
        







        protected string RequisitarEmissaoSicrona(IEnvioReq envioReq, Projeto projeto, string cnpjEmintente, string tpAmb, string tpDown, string caminho, bool exibirNaTela, bool a3)
        {
            string resposta = envioReq.EnviarEmissao(a3);
            var emitirRespBPe = JsonConvert.DeserializeObject<EmitirRespBPe>(resposta);
            respostaSincrona.statusEnvio = emitirRespBPe.status;

            switch (emitirRespBPe.status)
            {
                case "200":
                case "-6":
                    {
                        Thread.Sleep(NSSuite.TempoEspera);

                        ConsStatusProcessamentoReqBPe consultarReq = new ConsStatusProcessamentoReqBPe
                        {
                            CNPJ = cnpjEmitente,
                            nsNRec = emitirRespBPe.nsNRec,
                            tpAmb = tpAmb
                        };
                        resposta = consultarReq.EnviarConsultaStatusProcesamento();
                        var consultarResp = JsonConvert.DeserializeObject<ConsStatusProcessamentoRespBPe>(resposta);
                        respostaSincrona.statusConsulta = consultarResp.status;

                        if (consultarResp.status.Equals("-2"))
                        {
                            if (consultarResp.cStat.Equals("996"))
                            {
                                for (int i = 1; i < 3; i++)
                                {
                                    Comuns.gravarLinhaLog("[REALIZANDO_CONSULTA_NOVAMENTE...]");
                                    Thread.Sleep(600 - (i * 100));
                                    resposta = consultarReq.EnviarConsultaStatusProcesamento();
                                    consultarResp = JsonConvert.DeserializeObject<ConsStatusProcessamentoRespBPe>(resposta);

                                    if (!consultarResp.status.Equals("-2"))
                                    {
                                        respostaSincrona.statusConsulta = consultarResp.status;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                respostaSincrona.cStat = consultarResp.erro.cStat;
                                respostaSincrona.motivo = consultarResp.erro.xMotivo;
                            }
                        }

                        if (consultarResp.status.Equals("200"))
                        {
                            if (consultarResp.cStat.Equals("100"))
                            {
                                DownloadReqBPe downloadReqBPe = new DownloadReqBPe()
                                {
                                    chBPe = consultarResp.chBPe,
                                    tpAmb = tpAmb,
                                    tpDown = tpDown
                                };
                                resposta = downloadReqBPe.EnviarDownloadESalvar(caminho, exibirNaTela);
                                var downloadRespBPe = JsonConvert.DeserializeObject<DownloadRespBPe>(resposta);
                                respostaSincrona.statusDownload = downloadRespBPe.status;

                                if (!downloadRespBPe.status.Equals("200"))
                                    respostaSincrona.motivo = downloadRespBPe.motivo;
                            }
                            else
                                respostaSincrona.motivo = consultarResp.xMotivo;
                        }
                        else
                            respostaSincrona.motivo = consultarResp.motivo;

                        break;
                    }
                case "-4":
                case "-2":
                    {
                        respostaSincrona.motivo = emitirRespBPe.motivo;
                        respostaSincrona.erros = emitirRespBPe.erros;
                        break;
                    }
                case "-5":
                    {
                        respostaSincrona.cStat = emitirRespBPe.erro.cStat;
                        respostaSincrona.motivo = emitirRespBPe.erro.xMotivo;
                        break;
                    }
                default:
                    {
                        respostaSincrona.motivo = emitirRespBPe.motivo;

                        break;
                    }
            }


        }
    } 
}
