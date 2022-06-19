using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IMedidasRepository
    {
        Task<IEnumerable<Medida>> ObterMedidasPorAtletaAsync(int idAtleta, Paginacao paginacao);
        Task<IEnumerable<Medida>> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo, Paginacao paginacao);
        Task<Medida> ObterMedidaPorIDAsync(int id);
        Task<int> ObterTotalMedidasAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo);
        Task<int> ObterTotalMedidasAsync(int idAtleta);
        Task InserirMedidaAsync(Medida medida);
        Task AlterarMedidaAsync(Medida medida);
        Task ExcluirMedidaAsync(Medida medida);
    }
}