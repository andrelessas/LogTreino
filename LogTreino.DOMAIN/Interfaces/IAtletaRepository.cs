using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAtletaRepository
    {
        Task<IEnumerable<Atleta>> ObterAtletasAsync();
        Task<Atleta> ObterAtletaAsync(int id);
        Task AlterarAtletaAsync(Atleta atleta);
        Task InserirAtletaAsync(Atleta atleta);
        Task DeletarAtletaAsync(Atleta atleta, int id);
    }
}