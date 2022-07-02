using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using LogTreino.DATA;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAtletaRepository:IRepository<Atleta>
    {
        Task<IEnumerable<Atleta>> ObterAtletaPorNome(string nome);
        Task<int> ObterTotalAtletasAsync();
    }
}