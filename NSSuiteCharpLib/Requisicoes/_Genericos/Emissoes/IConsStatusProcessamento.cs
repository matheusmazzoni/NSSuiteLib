using NSSuiteCSharpLib.Respostas._Genéricas;


namespace NSSuiteCSharpLib.Requisicoes._Genericos.Emissoes
{
    public interface IConsStatusProcessamento
    {  
        string CNPJEmitente { get; set; }
        string NumeroRequisicaoNS { get; set; }
        int TipoDeAmbiente { get; set; }

        ConsStatusProcessamentoResp ConsultaStatusProcesamentoDFe();
        ConsStatusProcessamentoResp EnviarConsultaStatusProcesamento();
    }
}
