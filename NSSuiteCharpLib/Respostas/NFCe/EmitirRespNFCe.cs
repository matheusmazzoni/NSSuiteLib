﻿using NSSuiteCSharpLib.Respostas._Genéricas;
using NSSuiteCSharpLib.Respostas._Genéricas.Emissoes;
using System.Collections.Generic;
public class EmitirRespNFCe : IEmitirResp
{  
    public string status { get; set; }
    public string motivo { get; set; }
    public string xMotivo { get; set; }
    public List<string> erros { get; set; }
    public Erro erro { get; set; }
    public NfeProc nfeProc { get; set; }
}