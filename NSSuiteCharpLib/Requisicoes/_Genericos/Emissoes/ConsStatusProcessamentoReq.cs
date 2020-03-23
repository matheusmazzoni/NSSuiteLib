

using NSSuiteCSharpLib.Requisicoes._Genericos.Padroes;

namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public abstract class ConsStatusProcessamentoReq : Emissao
    {
        public string CNPJ { get; set; }
        public string nsNRec { get; set; }
        public string tpAmb { get; set; }

        public abstract string EnviarConsultaStatusProcesamento();
    }
}
