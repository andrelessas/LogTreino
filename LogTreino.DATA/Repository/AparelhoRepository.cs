using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA.Context;
using LogTreino.DOMAIN;
using LogTreino.DOMAIN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Repository
{
    public class AparelhoRepository : Repository<Aparelho>, IAparelhoRepository
    {
        public AparelhoRepository(LogTreinoContext context)
            :base(context)
        {
            
        }
        public async Task<int> ObterTotalAparelhosAsync()
        {
            return await _context.Aparelhos.CountAsync();
        }
    }
}