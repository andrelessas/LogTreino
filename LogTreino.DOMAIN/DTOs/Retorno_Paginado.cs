using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class Retorno_Paginado
    {
        public decimal TotalPaginas { get; set; }
        public object Dados { get; set; }
    }
}