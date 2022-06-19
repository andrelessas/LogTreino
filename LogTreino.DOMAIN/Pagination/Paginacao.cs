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
        public decimal TotalPaginas { get; set; }

        public Paginacao TratarPaginacao(int currentPage,int limit,int totalRegistros)
        {
            decimal totalPaginas = Math.Ceiling(totalRegistros / (decimal)limit);
            currentPage = currentPage > (totalRegistros / limit) ? (int)totalPaginas : currentPage;
            CurrentPage = limit * (currentPage - 1) < 0 ? 0 : limit * (currentPage - 1);
            TotalPaginas = totalPaginas;
            return this;
        }
    }
}