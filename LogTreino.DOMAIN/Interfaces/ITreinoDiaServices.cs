using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface ITreinoDiaServices
    {
        Task InserirTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO);
        Task AlterarTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO);
        Task ExcluirTreinoDiaAsync(int id);
        Task<TreinoDiaDTO> ObterTreinoDiaPorID(int id);
        Task<Retorno_Paginado> ObterTreinosPorAtleta(TreinoDiaDTO treinoDia,PaginacaoDTO paginacaoDTO);
        Task<Retorno_Paginado> ObterTreinosPorData(TreinoDiaDTO treinoDia,PaginacaoDTO paginacaoDTO);
    }
}