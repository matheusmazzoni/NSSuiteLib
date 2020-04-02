using NSSuiteCSharpLib.Respostas._Genéricas;


namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IConsStatusProcessamento
    {
        string CNPJ { get; set; }
        string nsNRec { get; set; }
        int tpAmb { get; set; }

        ConsStatusProcessamentoResp ConsultaStatusProcesamentoDFe();
        ConsStatusProcessamentoResp EnviarConsultaStatusProcesamento();
    }
}
