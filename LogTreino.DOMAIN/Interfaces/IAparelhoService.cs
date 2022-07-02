using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAparelhoService
    {
        Task InserirAparelhoAsync(Aparelho_Insert aparelho_Insert);
        Task AlterarAparelhoAsync(Aparelho_Update aparelho_Update);
        Task ExcluirAparelhoAsync(int id);
        Task<Aparelho_Update> ObterAparelhoPorIDAsync(int id);
        Task<Retorno_Paginado> ObterAparelhosAsync(PaginacaoDTO paginacaoDTO);
    }
}