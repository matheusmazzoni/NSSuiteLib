using NSSuiteCSharpLib.Requisicoes.BPe;
using System.Collections.Generic;

namespace testeLib.Modelos
{
    public class TemplateBPe
    {
        public EnvioReqBPe BPeRoot { get; private set; }

        public TemplateBPe()
        {
            BPeRoot = new EnvioReqBPe
            {
                BPe = new BPe
                {
                    infBPe = new InfBPe
                    {
                        versao = "1.00",
                        ide = new Ide
                        {
                            cUF = "43",
                            tpAmb = "2",
                            mod = "63",
                            serie = "0",
                            nBP = "8",
                            cBP = "00000008",
                            modal = "1",
                            dhEmi = "2020-03-20T23:59:59-03:00",
                            tpEmis = "1",
                            verProc = "1.00",
                            tpBPe = "0",
                            indPres = "1",
                            UFIni = "RS",
                            cMunIni = "4314902",
                            UFFim = "PR",
                            cMunFim = "4106902"
                        },
                        emit = new Emit
                        {
                            //IEST(Opcional)
                            //xFant(Opcional)
                            CNPJ = "11111111111111",
                            IE = "1111111111",
                            xNome = "EMPRESA TESTE",
                            IM = "516830",
                            CNAE = "1234567",
                            CRT = "1",
                            enderEmit = new EnderEmit
                            {
                                xLgr = "RUA ANTONIO DURO",
                                nro = "870",
                                xBairro = "CENTRO",
                                cMun = "4303509",
                                xMun = "CAMAQUA",
                                UF = "RS"
                            },
                            TAR = "113645236"
                        },
                        comp = new Comp //(Opcional)
                        {
                            xNome = "JOHN DOE",
                            CPF = "11111111111", // CNPJ ou idEstrangeiro
                                                 //IE (Opcional)
                            enderComp = new EnderComp
                            {
                                xLgr = "RUA ANDRADAS EM CURITIBANAS",
                                nro = "870",
                                xBairro = "CENTRO",
                                cMun = "4106902",
                                xMun = "CURITIBA",
                                UF = "PR"
                            }
                        },
                        agencia = new Agencia // (Opcional)
                        {
                            xNome = "AGENCIA LTDA",
                            CNPJ = "11111111111111",
                            enderAgencia = new EnderAgencia
                            {
                                xLgr = "Largo Vespasiano Julio Veppo",
                                nro = "870",
                                xBairro = "CENTRO",
                                cMun = "4303509",
                                xMun = "CAMAQUA",
                                UF = "RS",
                                // xCpl (Opcional)
                                // CEP (Opcional)
                                // cPais (Opcional)
                                // xPais (Opcional)
                                // fone (Opcional)
                                // email (Opcional)
                            }
                        },
                        infPassagem = new InfPassagem { },
                        infValorBPe = new InfValorBPe { },
                        imp = new Imp { }
                    }
                }
            };
           
            BPeRoot.BPe.infBPe.infViagem = new List<InfViagem>();
            for (int i = 0; i < 2; i++)
            {
                BPeRoot.BPe.infBPe.infViagem.Add(new InfViagem()
                {
                    cPercurso = "cPercurso",
                    xPercurso = " teste da descricao do percurso",
                    tpViagem = "00",
                    tpServ = "4",
                    tpAcomodacao = "1",
                    tpTrecho = "1",
                    dhViagem = "2020-03-05T11:23:00-03:00 "
                });
            }
        }

    }
}
