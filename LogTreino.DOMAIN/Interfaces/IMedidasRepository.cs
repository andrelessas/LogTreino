using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IMedidasRepository:IRepository<Medida>
    {
        Task<IEnumerable<Medida>> ObterMedidasPorAtletaAsync(int idAtleta, Paginacao paginacao);
        Task<IEnumerable<Medida>> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo, Paginacao paginacao);
        Task<int> ObterTotalMedidasAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo);
        Task<int> ObterTotalMedidasAsync(int idAtleta);
    }
}