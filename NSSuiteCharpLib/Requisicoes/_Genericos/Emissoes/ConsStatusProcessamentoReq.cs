

using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System.Threading;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class ConsStatusProcessamentoReq : Emissao
    {
        public string CNPJ { get; set; }
        public string nsNRec { get; set; }
        public string tpAmb { get; set; }

        public abstract string EnviarConsultaStatusProcesamento();

        public virtual void TratamentoConsultaEmissao(ConsStatusProcessamentoReq consultarReq, string resposta)
        {
            dynamic consultarResp = JsonConvert.DeserializeObject(resposta);
            if (!consultarResp.status.Equals("200"))
            {
                if (consultarResp.status.Equals("-2"))
                {
                    if (consultarResp.cStat.Equals("996"))
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            Comuns.gravarLinhaLog("[REALIZANDO_CONSULTA_NOVAMENTE...]");
                            Thread.Sleep(600 - (i * 100));
                            resposta = consultarReq.EnviarConsultaStatusProcesamento();
                            consultarResp = JsonConvert.DeserializeObject(resposta);

                            if (!consultarResp.status.Equals("-2"))
                                if (consultarResp.cStat.Equals("100"))
                                    break;
                                else
                                    throw new RequisicaoConsultaEmissaoException(consultarResp.xMotivo);
                        }
                    }
                    else
                        throw new RequisicaoConsultaEmissaoException(consultarResp.erro.xMotivo + 
                            ". Intetifador cStat: " + consultarResp.erro.cStat);
                }
                else
                    throw new RequisicaoConsultaEmissaoException(consultarResp.motivo);       
            }
        }
    }
}
