
using Newtonsoft.Json;
using NSSuiteCSharpLib.Genericos;
using NSSuiteCSharpLib.Genericos.Exceptions;
using NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes;
using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace NSSuiteCSharpLib.Requisicoes.BPe
{
    public class InfRespTec
    {
        public string CNPJ { get; set; }
        public string xContato { get; set; }
        public string email { get; set; }
        public string fone { get; set; }
        [XmlElement(IsNullable = false)]
        public string idCSRT { get; set; }
        [XmlElement(IsNullable = false)]
        public string hashCSRT { get; set; }
    }

    public class InfAdic
    {
        [XmlElement(IsNullable = false)]
        public string infAdFisco { get; set; }
        [XmlElement(IsNullable = false)]
        public string infCpl { get; set; }
    }

    public class AutXML
    {
        [XmlElement(IsNullable = false)]
        public string CNPJ { get; set; }
        [XmlElement(IsNullable = false)]
        public string CPF { get; set; }
    }

    public class Card
    {
        public string tpIntegra { get; set; }
        [XmlElement(IsNullable = false)]
        public string CNPJ { get; set; }
        [XmlElement(IsNullable = false)]
        public string tBand { get; set; }
        [XmlElement(IsNullable = false)]
        public string xBand { get; set; }
        [XmlElement(IsNullable = false)]
        public string cAut { get; set; }
        [XmlElement(IsNullable = false)]
        public string nsuTrans { get; set; }
        [XmlElement(IsNullable = false)]
        public string nsuHos { get; set; }
        [XmlElement(IsNullable = false)]
        public string nParcelas { get; set; }
        [XmlElement(IsNullable = false)]
        public string infAdCard { get; set; }


    }

    public class Pag
    {
        [XmlElement(IsNullable = false)]
        public string xPag { get; set; }
        [XmlElement(IsNullable = false)]
        public string nDocPag { get; set; }
        public string tPag { get; set; }
        public string vPag { get; set; }
        [XmlElement(IsNullable = false)]
        public Card card { get; set; }
    }

    public class ICMS00
    {
        public string CST { get; set; }
        public string vBC { get; set; }
        public string pICMS { get; set; }
        public string vICMS { get; set; }
    }

    public class ICMS20
    {
        public string CST { get; set; }
        public string pRedBC { get; set; }
        public string vBC { get; set; }
        public string pICMS { get; set; }
        public string vICMS { get; set; }
    }

    public class ICMS45
    {
        public string CST { get; set; }
    }

    public class ICMS90
    {
        public string CST { get; set; }
        [XmlElement(IsNullable = false)]
        public string pRedBC { get; set; }
        public string vBC { get; set; }
        public string pICMS { get; set; }
        public string vICMS { get; set; }
        [XmlElement(IsNullable = false)]
        public string vCred { get; set; }
    }

    public class ICMSOutraUF
    {
        public string CST { get; set; }
        public string qRedBCOutraUF { get; set; }
        public string vBCOutraUF { get; set; }
        public string pICMSOutraUF { get; set; }
        public string vICMSOutraUF { get; set; }
    }

    public class ICMSSN
    {
        public string CST { get; set; }
        public string indSN { get; set; }
        [XmlElement(IsNullable = false)]
        public string vTotTrib { get; set; }
        [XmlElement(IsNullable = false)]
        public string infAdFisco { get; set; }
    }

    public class ICMSUFFim
    {
        public string vBCUFFim { get; set; }
        public string pFCPUFFim { get; set; }
        public string pICMSUFFim { get; set; }
        public string pICMSInter { get; set; }
        public string pICMSInterPart { get; set; }
        public string vFCPUFFim { get; set; }
        public string vICMSUFFim { get; set; }
        public string vICMSUFIni { get; set; }
    }

    public class ICMS
    {
        [XmlElement(IsNullable = false)]
        public ICMS00 ICMS00 { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMS20 ICMS20 { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMS45 ICMS45 { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMS90 ICMS90 { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMSOutraUF ICMSOutraUF { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMSSN ICMSSN { get; set; }
        [XmlElement(IsNullable = false)]
        public ICMSUFFim ICMSUFFim { get; set; }
    }

    public class Imp
    {
        public ICMS ICMS { get; set; }
    }

    public class InfPassageiro
    {
        public string xNome { get; set; }
        [XmlElement(IsNullable = false)]
        public string CPF { get; set; }
        public string tpDoc { get; set; }
        [XmlElement(IsNullable = false)]
        public string nDoc { get; set; }
        [XmlElement(IsNullable = false)]
        public string xDoc { get; set; }
        [XmlElement(IsNullable = false)]
        public string dNasc { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone { get; set; }
        [XmlElement(IsNullable = false)]
        public string email { get; set; }
    }

    public class InfPassagem
    {
        public string cLocOrig { get; set; }
        public string xLocOrig { get; set; }
        public string cLocDest { get; set; }
        public string xLocDest { get; set; }
        public string dhEmb { get; set; }
        public string dhValidade { get; set; }
        [XmlElement(IsNullable = false)]
        public InfPassageiro infPassageiro { get; set; }
    }

    public class InfTravessia
    {
        public string tpVeiculo { get; set; }
        public string sitVeiculo { get; set; }
    }

    public class InfViagem
    {
        public string cPercurso { get; set; }
        public string xPercurso { get; set; }
        public string tpViagem { get; set; }
        public string tpServ { get; set; }
        public string tpAcomodacao { get; set; }
        public string tpTrecho { get; set; }
        public string dhViagem { get; set; }
        [XmlElement(IsNullable = false)]
        public string dhConexao { get; set; }
        [XmlElement(IsNullable = false)]
        public string prefixo { get; set; }
        [XmlElement(IsNullable = false)]
        public string poltrona { get; set; }
        [XmlElement(IsNullable = false)]
        public string plataforma { get; set; }
        [XmlElement(IsNullable = false)]
        public InfTravessia infTravessia { get; set; }
    }

    public class InfValorBPe
    {
        public string vBP { get; set; }
        public string vDesconto { get; set; }
        public string vPgto { get; set; }
        public string vTroco { get; set; }
        [XmlElement(IsNullable = false)]
        public string tpDesconto { get; set; }
        [XmlElement(IsNullable = false)]
        public string xDesconto { get; set; }
        public string cDesconto { get; set; }
        public List<Comp> Comp { get; set; }
    }

    public class InfBPeSub
    {
        public string chBPe { get; set; }
        public string tpSub { get; set; }
    }

    public class EnderAgencia
    {
        public string xLgr { get; set; }
        public string nro { get; set; }
        [XmlElement(IsNullable = false)]
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        [XmlElement(IsNullable = false)]
        public string CEP { get; set; }
        public string UF { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone { get; set; }
        [XmlElement(IsNullable = false)]
        public string email { get; set; }
    }

    public class Agencia
    {
        public string xNome { get; set; }
        public string CNPJ { get; set; }
        public EnderAgencia enderAgencia { get; set; }
    }

    public class EnderComp
    {
        public string xLgr { get; set; }
        public string nro { get; set; }
        [XmlElement(IsNullable = false)]
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        [XmlElement(IsNullable = false)]
        public string CEP { get; set; }
        public string UF { get; set; }
        [XmlElement(IsNullable = false)]
        public string cPais { get; set; }
        [XmlElement(IsNullable = false)]
        public string xPais { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone { get; set; }
        [XmlElement(IsNullable = false)]
        public string email { get; set; }
    }

    public class Comp
    {
        public string tpComp { get; set; }
        public string vComp { get; set; }
        public string xNome { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string idEstrangeiro { get; set; }
        [XmlElement(IsNullable = false)]
        public string IE { get; set; }
        public EnderComp enderComp { get; set; }
    }

    public class EnderEmit
    {
        public string xLgr { get; set; }
        public string nro { get; set; }
        [XmlElement(IsNullable = false)]
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        [XmlElement(IsNullable = false)]
        public string CEP { get; set; }
        public string UF { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone { get; set; }
        [XmlElement(IsNullable = false)]
        public string email { get; set; }
    }

    public class Emit
    {
        public string CNPJ { get; set; }
        public string IE { get; set; }
        [XmlElement(IsNullable = false)]
        public string IEST { get; set; }
        public string xNome { get; set; }
        [XmlElement(IsNullable = false)]
        public string xFant { get; set; }
        [XmlElement(IsNullable = false)]
        public string IM { get; set; }
        [XmlElement(IsNullable = false)]
        public string CNAE { get; set; }
        [XmlElement(IsNullable = false)]
        public string CRT { get; set; }
        public EnderEmit enderEmit { get; set; }
        [XmlElement(IsNullable = false)]
        public string TAR { get; set; }
    }

    public class Ide
    {
        public string cUF { get; set; }
        public string tpAmb { get; set; }
        public string mod { get; set; }
        public string serie { get; set; }
        public string nBP { get; set; }
        public string cBP { get; set; }
        [XmlElement(IsNullable = false)]
        public string cDV { get; set; }
        public string modal { get; set; }
        public string dhEmi { get; set; }
        public string tpEmis { get; set; }
        public string verProc { get; set; }
        public string tpBPe { get; set; }
        public string indPres { get; set; }
        public string UFIni { get; set; }
        public string cMunIni { get; set; }
        public string UFFim { get; set; }
        public string cMunFim { get; set; }
        [XmlElement(IsNullable = false)]
        public string chCont { get; set; }
        [XmlElement(IsNullable = false)]
        public string xJust { get; set; }
    }

    public class InfBPe
    {
        [XmlAttribute]
        public string versao { get; set; }
        public Ide ide { get; set; }
        public Emit emit { get; set; }
        [XmlElement(IsNullable = false)]
        public Comp comp { get; set; }
        [XmlElement(IsNullable = false)]
        public Agencia agencia { get; set; }
        [XmlElement(IsNullable = false)]
        public InfBPeSub infBPeSub { get; set; }
        public InfPassagem infPassagem { get; set; }
        public List<InfViagem> infViagem { get; set; }
        public InfValorBPe infValorBPe { get; set; }
        public Imp imp { get; set; }
        public List<Pag> pag { get; set; }
        [XmlElement(IsNullable = false)]
        public List<AutXML> autXML { get; set; }
        [XmlElement(IsNullable = false)]
        public InfAdic infAdic { get; set; }
        [XmlElement(IsNullable = false)]
        public InfRespTec infResptec { get; set; }
    }

    public class BPe
    {
        public InfBPe infBPe { get; set; }
    }

    public class EnvioReqBPe : Emissao, IEnvioReq
    {
        public BPe BPe { get; set; }
        public dynamic TratamentoEnviarEmissao(string resposta)
        {
            dynamic emitirResp = JsonConvert.DeserializeObject(resposta);
            switch (emitirResp.status)
            {
                case "200":
                case "-6":
                    return emitirResp;
                case "-4":
                case "-2":
                    throw new RequisicaoEmissaoException(emitirResp.motivo + ". Erros: " + emitirResp.erros);
                case "-5":
                    throw new RequisicaoEmissaoException(emitirResp.erro.XMotivo + 
                        ". cStat: " + emitirResp.erro.cStat);
                default:
                    throw new RequisicaoEmissaoException(emitirResp.motivo);
            }
        }
        public XmlDocument GerarXMLEnvio()
        {
            return GerarXMLDocumento(BPe);
        }
        public dynamic EnviarEmissao(bool a3)
        {
            string resposta;
            if (a3)
            {
                string versao = BPe.infBPe.versao;
                string cUF = BPe.infBPe.ide.cUF;
                string dhEmi = BPe.infBPe.ide.dhEmi;
                string cnpjEmitente = BPe.infBPe.emit.CNPJ;
                string serie = BPe.infBPe.ide.serie;
                string nBP = BPe.infBPe.ide.nBP;
                string tpEmis = BPe.infBPe.ide.tpEmis;
                string cBP = BPe.infBPe.ide.cBP;
                resposta = EnviarEmissaoComAssinatura(this, Projeto.BPe, versao, cUF, dhEmi, serie, nBP, tpEmis, cBP,
                    cnpjEmitente, Endpoints.BPeEnvio);
            }
            else
                resposta =  EnviarEmissao(Projeto.BPe, JsonConvert.SerializeObject(this), Endpoints.BPeEnvio);            
            return TratamentoEnviarEmissao(resposta);
        }
        public void EnviarEmissaoSincrona(string tpDown, string caminho, bool exibirNaTela, bool a3)
        {
            string cnpjEmitente = BPe.infBPe.emit.CNPJ;
            string tpAmb = BPe.infBPe.ide.tpAmb;
            RequisitarEmissaoSicrona(this, Projeto.BPe, cnpjEmitente, tpAmb, tpDown, caminho, exibirNaTela, a3);
        }
    }
}
