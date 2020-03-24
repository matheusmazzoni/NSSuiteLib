using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSuiteCSharpLib.Genericos.Exceptions
{
    public class RequisicaoConsultaEmissaoException : ErroRequisicaoAPIException
    {
        public RequisicaoConsultaEmissaoException(string msg) : base(msg)
        {
        }
    }
}
