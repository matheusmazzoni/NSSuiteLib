using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas._Genéricas.Emissoes;
using NSSuiteCSharpLib.Respostas.BPe.Emissoes;


namespace NSSuiteCSharpLib.Requisicoes.BPe.Emissoes
{
    public partial class TBPe : TemplateEnvioReq
    {
        //Metodos de Envio para API
        protected override IDownload GetObjectDownload(ConsStatusProcessamentoResp consultarResp, string tpDown)
        {
            var downloadReq = new DownloadReqBPe
            {
                tpAmb = (int)this.infBPe.ide.tpAmb,
                tpDown = tpDown
            };
            downloadReq.ChaveBPe = (consultarResp as ConsStatusProcessamentoRespBPe).chBPe;
            return downloadReq;
        }
        protected override IConsStatusProcessamento GetObjectConsStatusProcessamento(string nsNRec)
        {
            var consStatus = new ConsStatusProcessamentoReqBPe
            {
                CNPJEmitente = this.infBPe.emit.CNPJ,
                tpAmb = (int)this.infBPe.ide.tpAmb,
                NumeroRequisicaoNS = nsNRec
            };

            return consStatus;
        }
        public override string EnviarEmissao(bool a3)
        {
            IEmitirResp resposta;
            if (a3)
            {
                string cUF = ((int)this.infBPe.ide.cUF).ToString();
                string dhEmi = this.infBPe.ide.dhEmi;
                string cnpjEmitente = this.infBPe.emit.CNPJ;
                string serie = this.infBPe.ide.serie;
                string nBP = this.infBPe.ide.nBP;
                string tpEmis = ((int)this.infBPe.ide.tpEmis).ToString();
                string cBP = this.infBPe.ide.cBP;
                resposta = EnviarEmissaoDocumentoComAssinatura(this, Projeto.BPe, cUF, dhEmi, serie, nBP, tpEmis, cBP,
                    cnpjEmitente, "infBPe", Endpoints.BPeEnvio);
            }
            else
                //Falar sobre o JSON
                resposta = EnviarEmissaoDocumento(Projeto.BPe, Comuns.GerarXMLDocumento(this), Endpoints.BPeEnvio, "xml");
            switch (resposta.status)
            {
                case "200":
                case "-6":
                    return (resposta as EmitirResp).nsNRec;
                case "-4":
                case "-2":
                    throw new RequisicaoEmissaoException($"{resposta.motivo}. \nErros: {resposta.erros}");
                case "-5":
                    throw new RequisicaoEmissaoException($"{resposta.erro.xMotivo}. \ncStat: {resposta.erro.cStat}");
                default:
                    throw new RequisicaoEmissaoException(resposta.motivo);
            }
        }
        public override string GerarXMLEnvio(string chave)
        {
            if (string.IsNullOrEmpty(this.infBPe.Id))
                this.infBPe.Id = Projeto.BPe.ToString() + chave;

            this.infBPe.ide.cDV = chave.Substring(chave.Length - 1, 1);
            string cUF = this.infBPe.ide.cUF.ToString();
            //Cada projeto cuidará do seu qr code SEPARADAMENTE
            //GenerateQrcode(this, cUF)
            return Comuns.GerarXMLDocumento(this);
        }
    }
}
