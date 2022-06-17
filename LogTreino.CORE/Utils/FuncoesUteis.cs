using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.CORE.Utils
{
    public class FuncoesUteis
    {
        public decimal[] TratarPaginacao(int currentPage, int limit, decimal totalRegistros)
        {
            decimal[] retorno = new decimal[2];
            decimal totalPaginas = Math.Ceiling(totalRegistros / limit);
            currentPage = currentPage > (totalRegistros / limit) ? (int)totalPaginas : currentPage;
            currentPage = limit * (currentPage - 1) < 0 ? 0 : limit * (currentPage - 1);
            retorno[0] = totalPaginas;
            retorno[1] = currentPage;
            return retorno;
        }

    }
}