using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class PaginacaoDTO
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
    }
}