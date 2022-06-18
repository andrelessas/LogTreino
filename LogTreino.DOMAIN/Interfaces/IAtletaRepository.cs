using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using LogTreino.DATA;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAtletaRepository
    {
        Task<IEnumerable<Atleta>> ObterAtletasAsync(int currentPage,int limit);
        Task<Atleta> ObterAtletaPorIDAsync(int id);
        Task<IEnumerable<Atleta>> ObterAtletaPorNome(string nome);
        Task<int> ObterTotalAtletasAsync();
        Task AlterarAtletaAsync(Atleta atleta);
        Task InserirAtletaAsync(Atleta atleta);
        Task DeletarAtletaAsync(Atleta atleta);
    }
}