using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface ITreinoDiaRepository:IRepository<TreinoDia>
    {
        Task<int> ObterTotalTreinoDias(DateTime dataInicial, DateTime dataFinal);
        Task<int> ObterTotalTreinoDias(int idAtleta);
        Task<IEnumerable<TreinoDia>> ObterTreinosPorAtleta(int idAtleta,Paginacao paginacao);
        Task<IEnumerable<TreinoDia>> ObterTreinosPorPeriodo(DateTime dataInicial, DateTime dataFinal,Paginacao paginacao);
    }
}