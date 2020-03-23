namespace NSSuiteCSharpLib.Genericos
{
    internal class Endpoints
    {
        // BP-e
        public static string BPeEnvio { get; set; } = "https://bpe.ns.eti.br/v1/bpe/issue";
        public static string BPeConsStatusProcessamento { get; set; } = "https://bpe.ns.eti.br/v1/bpe/issue/status";
        public static string BPeDownload { get; set; } = "https://bpe.ns.eti.br/v1/bpe/get";
        public static string BPeDownloadEvento { get; set; } = "https://bpe.ns.eti.br/v1/bpe/get/event";
        public static string BPeCancelamento { get; set; } = "https://bpe.ns.eti.br/v1/bpe/cancel";
        public static string BPeNaoEmb { get; set; } = "https://bpe.ns.eti.br/v1/bpe/naoemb";
        public static string BPeConsSit { get; set; } = "https://bpe.ns.eti.br/v1/bpe/status";
        public static string BPeAlteraPoltrona { get; set; } = "https://bpe.ns.eti.br/v1/bpe/alterpol";

        // CT-e
        public static string CTeEnvio { get; set; } = "https://cte.ns.eti.br/cte/issue";
        public static string CTeOSEnvio { get; set; } = "https://cte.ns.eti.br/cte/issueos";
        public static string CTeConsStatusProcessamento { get; set; } = "https://cte.ns.eti.br/cte/issueStatus/300";
        public static string CTeDownload { get; set; } = "https://cte.ns.eti.br/cte/get/300";
        public static string CTeDownloadEvento { get; set; } = "https://cte.ns.eti.br/cte/get/event/300";
        public static string CTeCancelamento { get; set; } = "https://cte.ns.eti.br/cte/cancel/300";
        public static string CTeCCe { get; set; } = "https://cte.ns.eti.br/cte/cce/300";
        public static string CTeConsCad { get; set; } = "https://cte.ns.eti.br/util/conscad";
        public static string CTeConsSit { get; set; } = "https://cte.ns.eti.br/cte/stats/300";
        public static string CTeInfGTV { get; set; } = "https://cte.ns.eti.br/cte/gtv";
        public static string CTeInutilizacao { get; set; } = "https://cte.ns.eti.br/cte/inut";
        public static string CTeListarNSNRecs { get; set; } = "https://cte.ns.eti.br/util/list/nsnrecs";

        // MDF-e
        public static string MDFeEnvio { get; set; } = "https://mdfe.ns.eti.br/mdfe/issue";
        public static string MDFeConsStatusProcessamento { get; set; } = "https://mdfe.ns.eti.br/mdfe/issue/status";
        public static string MDFeDownload { get; set; } = "https://mdfe.ns.eti.br/mdfe/get";
        public static string MDFeDownloadEvento { get; set; } = "https://mdfe.ns.eti.br/mdfe/get/event";
        public static string MDFeCancelamento { get; set; } = "https://mdfe.ns.eti.br/mdfe/cancel";
        public static string MDFeEncerramento { get; set; } = "https://mdfe.ns.eti.br/mdfe/closure";
        public static string MDFeIncCondutor { get; set; } = "https://mdfe.ns.eti.br/mdfe/adddriver";
        public static string MDFeConsNaoEncerrados { get; set; } = "https://mdfe.ns.eti.br/util/consnotclosed";
        public static string MDFeConsSit { get; set; } = "https://mdfe.ns.eti.br/mdfe/stats";
        public static string MDFePrevia { get; set; } = "https://mdfe.ns.eti.br/util/preview/mdfe";
        public static string MDFeListarNSNRecs { get; set; } = "https://mdfe.ns.eti.br/util/list/nsnrecs";

        // NFC-e
        public static string NFCeEnvio { get; set; } = "https://nfce.ns.eti.br/v1/nfce/issue";
        public static string NFCeDownload { get; set; } = "https://nfce.ns.eti.br/v1/nfce/get";
        public static string NFCeCancelamento { get; set; } = "https://nfce.ns.eti.br/v1/nfce/cancel";
        public static string NFCeConsSit { get; set; } = "https://nfce.ns.eti.br/v1/nfce/status";
        public static string NFCeEnvioEmail { get; set; } = "https://nfce.ns.eti.br/v1/util/resendemail";
        public static string NFCeInutilizacao { get; set; } = "https://nfce.ns.eti.br/v1/nfce/inut";

        // NF-e
        public static string NFeEnvio { get; set; } = "https://nfe.ns.eti.br/nfe/issue";
        public static string NFeConsStatusProcessamento { get; set; } = "https://nfe.ns.eti.br/nfe/issue/status";
        public static string NFeDownload { get; set; } = "https://nfe.ns.eti.br/nfe/get";
        public static string NFeDownloadEvento { get; set; } = "https://nfe.ns.eti.br/nfe/get/event";
        public static string NFeCancelamento { get; set; } = "https://nfe.ns.eti.br/nfe/cancel";
        public static string NFeCCe { get; set; } = "https://nfe.ns.eti.br/nfe/cce";
        public static string NFeConsStatusSefaz { get; set; } = "https://nfe.ns.eti.br/util/wssefazstatus";
        public static string NFeConsCad { get; set; } = "https://nfe.ns.eti.br/util/conscad";
        public static string NFeConsSit { get; set; } = "https://nfe.ns.eti.br/nfe/stats";
        public static string NFeEnvioEmail { get; set; } = "https://nfe.ns.eti.br/util/resendemail";
        public static string NFeInutilizacao { get; set; } = "https://nfe.ns.eti.br/nfe/inut";
        public static string NFeListarNSNRecs { get; set; } = "https://nfe.ns.eti.br/util/list/nsnrecs";
        public static string NFePrevia { get; set; } = "https://nfe.ns.eti.br/util/preview/nfe";
        public static string NFeGerarXMLEmissao { get; set; } = "https://nfe.ns.eti.br/util/generatexml";
        public static string NFeGerarXMLCancelamento { get; set; } = "https://nfe.ns.eti.br/util/generatecancel";
        public static string NFeGerarXMLCorrecao { get; set; } = "https://nfe.ns.eti.br/util/generatecce";
        public static string NFeGerarXMLInut { get; set; } = "https://nfe.ns.eti.br/util/generateinut";

    }
}