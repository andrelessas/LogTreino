using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.CORE.Shared
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string? Detalhes { get; set; }   
    }
}