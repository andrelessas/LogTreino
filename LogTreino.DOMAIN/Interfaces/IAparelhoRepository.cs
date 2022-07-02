using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAparelhoRepository:IRepository<Aparelho>
    {
        Task<int> ObterTotalAparelhosAsync();
    }
}