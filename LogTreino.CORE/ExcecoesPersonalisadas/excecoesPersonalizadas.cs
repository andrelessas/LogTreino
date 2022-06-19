using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.CORE.ExcecoesPersonalisadas
{
    public class ExcecoesPersonalizadas : Exception
    {
        public ExcecoesPersonalizadas(string? message) : base(message)
        {
        }
    }
}