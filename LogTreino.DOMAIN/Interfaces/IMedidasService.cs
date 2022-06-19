using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IMedidasService
    {
        Task<Retorno_Paginado> ObterMedidasPorAtletaAsync(int idAtleta, PaginacaoDTO paginacaoDTO);
        Task<Retorno_Paginado> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo, PaginacaoDTO paginacaoDTO);
        Task<Medida> ObterMedidaPorIDAsync(int id);
        Task InserirMedidaAsync(MedidasDTO medidasDTO);
        Task AlterarMedidaAsync(int id,MedidasDTO medidasDTO);
        Task ExcluirMedidaAsync(int id);
    }
}