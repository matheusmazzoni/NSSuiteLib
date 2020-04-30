using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using NSSuiteCSharpLib.Respostas._Genéricas.Emissoes;

namespace NSSuiteCSharpLib.Requisicoes.NFCe.Emissoes
{
    public partial class TNFCe : EmissaoCommuns, IEmissao
    {
        public string EnviarEmissao(bool a3)
        {
            IEmitirResp resposta;
            if (a3)
            {
                string cUF = ((int)this.infNFe.ide.cUF).ToString();
                string dhEmi = this.infNFe.ide.dhEmi;
                string cnpjEmitente = this.infNFe.emit.ItemElementName.ToString();
                string serie = this.infNFe.ide.serie;
                string nBP = this.infNFe.ide.nNF;
                string tpEmis = ((int)this.infNFe.ide.tpEmis).ToString();
                string cBP = this.infNFe.ide.cNF;
                resposta = EnviarEmissaoDocumentoComAssinatura(this, Projeto.NFCe, cUF, dhEmi, serie, nBP, tpEmis, cBP,
                    cnpjEmitente, "infNFe", Endpoints.BPeEnvio);
            }
            else
                resposta = EnviarEmissaoDocumento(Projeto.NFCe, Comuns.GerarXMLDocumento(this), Endpoints.NFCeEnvio, "xml");
            switch (resposta.status)
            {
                case "100":
                    return (resposta as EmitirRespNFCe).nfeProc.chNFe;
                case "-100":
                    throw new RequisicaoEmissaoException($"{(resposta as EmitirRespNFCe).nfeProc.xMotivo}." +
                        $" cStat: {(resposta as EmitirRespNFCe).nfeProc.cStat}");
                case "-995":
                    throw new RequisicaoEmissaoException($"{resposta.motivo}. Erros: {resposta.erros}");
                default:
                    throw new RequisicaoEmissaoException(resposta.motivo);
            }
        }
        public string GerarXMLEnvio(string chave)
        {
            if (string.IsNullOrEmpty(this.infNFe.Id))
                this.infNFe.Id = "NFe" + chave;

            this.infNFe.ide.cDV = chave.Substring(chave.Length - 1, 1);
            //GenerateQrcode(this)
            return Comuns.GerarXMLDocumento(this);
        }
        public void RequisitarEmissaoSicrona(string tpDown, string caminho, bool exibirNaTela, bool a3)
        {
            var chave = this.EnviarEmissao(a3);
            var downloadReq = new DownloadReqNFCe
            {
                chNFe = chave,
                tpAmb = (int)this.infNFe.ide.tpAmb,
                tpDown = tpDown,
            };
            downloadReq.EnviarDownloadESalvar(caminho, exibirNaTela);
        }
    }
}
