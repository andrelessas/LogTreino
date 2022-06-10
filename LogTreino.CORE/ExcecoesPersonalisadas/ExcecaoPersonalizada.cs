using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.CORE.ExcecoesPersonalisadas
{
    public class ExcecaoPersonalizada : Exception
    {
        public ExcecaoPersonalizada(string? message) : base(message)
        {
        }
    }
}