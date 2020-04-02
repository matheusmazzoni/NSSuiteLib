

using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Respostas._Genéricas;
using System.Threading;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class TemplateConsStatusProcessamentoReq : IConsStatusProcessamento
    {
        public string CNPJ { get; set; }
        public string nsNRec { get; set; }
        public int tpAmb { get; set; }

        public abstract ConsStatusProcessamentoResp ConsultaStatusProcesamentoDFe();
        public ConsStatusProcessamentoResp EnviarConsultaStatusProcesamento()
        {
            var consultarResp = ConsultaStatusProcesamentoDFe();
            switch (consultarResp.status)
            {
                case "200":
                    {
                        if (consultarResp.cStat.Equals("0"))
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                Comuns.gravarLinhaLog("[REALIZANDO_CONSULTA_NOVAMENTE...]");
                                Thread.Sleep(600 - (i * 100));
                                consultarResp = EnviarConsultaStatusProcesamento();

                                if (!consultarResp.status.Equals("-2"))
                                {
                                    if (consultarResp.cStat.Equals("100"))
                                        return consultarResp;
                                    else
                                        throw new RequisicaoConsultaEmissaoException(consultarResp.xMotivo);
                                }
                            }
                            throw new RequisicaoConsultaEmissaoException(consultarResp.xMotivo);
                        }

                        if (consultarResp.cStat.Equals("100"))
                            return consultarResp;
                        else
                            throw new RequisicaoConsultaEmissaoException($"{consultarResp.xMotivo}. " +
                             $"cStat: {consultarResp.cStat}");
                    }
                case "-2":
                    {
                        if (consultarResp.cStat.Equals("996"))
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                Comuns.gravarLinhaLog("[REALIZANDO_CONSULTA_NOVAMENTE...]");
                                Thread.Sleep(600 - (i * 100));
                                consultarResp = EnviarConsultaStatusProcesamento();

                                if (!consultarResp.status.Equals("-2"))
                                {
                                    if (consultarResp.cStat.Equals("100"))
                                        return consultarResp;
                                    else
                                        throw new RequisicaoConsultaEmissaoException(consultarResp.xMotivo);
                                }
                            }
                            throw new RequisicaoConsultaEmissaoException(consultarResp.xMotivo);
                        }
                        else
                            throw new RequisicaoConsultaEmissaoException(consultarResp.erro.xMotivo +
                                ". \ncStat: " + consultarResp.erro.cStat);
                    }
                default:
                    return consultarResp;
            }
        }
    }
}
