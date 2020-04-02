using NSSuiteCSharpLib.Requisicoes.BPe;
using System;
using System.Collections.Generic;

namespace testeLib.Modelos
{
    public class TemplateBPe
    {
        public TBPe BPe { get;}
        private int nDF { get; set; } = 67;
        private int Serie { get; set; }

        public TemplateBPe()
        {
            BPe = new TBPe
            {
                infBPe = new TBPeInfBPe()
                {
                    versao = "1.00",
                    ide = new TBPeInfBPeIde
                    {
                        cUF = TCodUfIBGE.Item43,
                        tpAmb = TAmb.Item2,
                        mod = TModBPe.Item63,
                        serie = Serie.ToString(),
                        nBP = nDF.ToString(),
                        cBP = "00000003",
                        modal = TBPeInfBPeIdeModal.Item1,
                        dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                        tpEmis = TBPeInfBPeIdeTpEmis.Item1,
                        verProc = "1.00",
                        tpBPe = TBPeInfBPeIdeTpBPe.Item0,
                        indPres = TIndPres.Item1,
                        UFIni = TUf_sem_EX.RS,
                        cMunIni = "4314902",
                        UFFim = TUf.PR,
                        cMunFim = "4106902"
                    },
                    emit = new TBPeInfBPeEmit
                    {
                        CNPJ = "07364617000135",
                        IE = "0170108708",
                        xNome = "EMPRESA TESTE",
                        IM = "516830",
                        CNAE = "1234567",
                        CRT = TBPeInfBPeEmitCRT.Item1,
                        enderEmit = new TEndeEmi
                        {
                            xLgr = "RUA ANTONIO DURO",
                            nro = "870",
                            xBairro = "CENTRO",
                            cMun = "4303509",
                            xMun = "CAMAQUA",
                            UF = TUf_sem_EX.RS
                        },
                        TAR = "113645236"
                    },
                    comp = new TBPeInfBPeComp
                    {
                        xNome = "JOHN DOE",
                        ItemElementName = ItemChoiceType.CPF,
                        Item = "11111111111",
                        enderComp = new TEndereco
                        {
                            xLgr = "RUA ANDRADAS EM CURITIBANAS",
                            nro = "870",
                            xBairro = "CENTRO",
                            cMun = "4106902",
                            xMun = "CURITIBA",
                            UF = TUf.PR
                        }
                    },
                    agencia = new TBPeInfBPeAgencia
                    {
                        xNome = "AGENCIA LTDA",
                        CNPJ = "07364617000135",
                        enderAgencia = new TEndereco
                        {
                            xLgr = "Largo Vespasiano Julio Veppo",
                            nro = "870",
                            xBairro = "CENTRO",
                            cMun = "4303509",
                            xMun = "CAMAQUA",
                            UF = TUf.RS
                        }
                    },
                    infPassagem = new TBPeInfBPeInfPassagem
                    {
                        cLocOrig = "4314902",
                        xLocOrig = "PORTO ALEGRE",
                        cLocDest = "PR",
                        xLocDest = "CURITIBA",
                        dhEmb = "2020-04-02T23:59:00-03:00",
                        dhValidade = "2021-04-02T23:59:00-03:00",
                        infPassageiro = new TBPeInfBPeInfPassagemInfPassageiro
                        {
                            xNome = "JOHN DOE",
                            CPF = "00269925074",
                            tpDoc = TDoc.Item1,
                            nDoc = "3076507718"
                        }
                    },
                    infViagem = new TBPeInfBPeInfViagem[1],
                    infValorBPe = new TBPeInfBPeInfValorBPe
                    {
                        vBP = "85.00",
                        vDesconto = "10.00",
                        vPgto = "75.00",
                        vTroco = "0.00",
                        tpDescontoSpecified = true,
                        tpDesconto = TBPeInfBPeInfValorBPeTpDesconto.Item02,
                        xDesconto = "TESTE DESCONTO",
                        cDesconto = "1234",
                        Comp = new TBPeInfBPeInfValorBPeComp[2]
                    },
                    imp = new TBPeInfBPeImp
                    {
                        ICMS = new TImp
                        {
                            Item = new TImpICMSSN
                            {
                                CST = TImpICMSSNCST.Item90,
                                indSN = TImpICMSSNIndSN.Item1
                            }
                        }
                    },
                    pag = new TBPeInfBPePag[1]                    
                },
            };

            BPe.infBPe.pag[0] = new TBPeInfBPePag
            {
                tPag = TBPeInfBPePagTPag.Item01,
                vPag = "75.00"
            };
            BPe.infBPe.infViagem[0] = new TBPeInfBPeInfViagem
            {
                tpTrecho = TBPeInfBPeInfViagemTpTrecho.Item1,
                cPercurso = "1",
                xPercurso = "teste da descricao do percurso",
                tpViagem = TBPeInfBPeInfViagemTpViagem.Item00,
                tpServ = TBPeInfBPeInfViagemTpServ.Item4,
                tpAcomodacao = TBPeInfBPeInfViagemTpAcomodacao.Item1,
                dhViagem = "2020-03-24T23:00:00-03:00",
            };
            BPe.infBPe.infValorBPe.Comp[0] = new TBPeInfBPeInfValorBPeComp
            {
                tpComp = TBPeInfBPeInfValorBPeCompTpComp.Item01,
                vComp = "65.00"
            };

            BPe.infBPe.infValorBPe.Comp[1] = new TBPeInfBPeInfValorBPeComp
            {
                tpComp = TBPeInfBPeInfValorBPeCompTpComp.Item02,
                vComp = "20.00"
            };
        }

    }
}
