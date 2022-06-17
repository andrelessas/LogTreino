using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.Pagination
{
    public class Paginacao
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
    }
}