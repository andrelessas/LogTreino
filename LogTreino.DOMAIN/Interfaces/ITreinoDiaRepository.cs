using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface ITreinoDiaRepository
    {
        Task InserirTreinoDiaAsync(TreinoDia treinoDia);
        Task AlterarTreinoDiaAsync(TreinoDia treinoDia);
        Task ExcluirTreinoDiaAsync(TreinoDia treinoDia);
        Task<int> ObterTotalTreinoDias(int idAtleta);
        Task<int> ObterTotalTreinoDias(DateTime data);
        Task<TreinoDia> ObterTreinoDiaPorID(int id);
        Task<IEnumerable<TreinoDia>> ObterTreinosPorAtleta(TreinoDia treinoDia,Paginacao paginacao);
        Task<IEnumerable<TreinoDia>> ObterTreinosPorData(TreinoDia treinoDia,Paginacao paginacao);
    }
}