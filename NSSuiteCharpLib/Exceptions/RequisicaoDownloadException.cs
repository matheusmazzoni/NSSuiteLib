using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSuiteCSharpLib.Genericos.Exceptions
{
    public class RequisicaoDownloadException : ErroRequisicaoAPIException
    {
        public RequisicaoDownloadException(string msg) : base(msg)
        {
        }
    }
}
