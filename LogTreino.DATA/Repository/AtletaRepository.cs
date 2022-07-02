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
    public class AtletaRepository:Repository<Atleta>, IAtletaRepository
    {  
        public AtletaRepository(LogTreinoContext context)
            :base(context)
        {
            
        }
        public async Task<IEnumerable<Atleta>> ObterAtletaPorNome(string nome)
        {
            return await _context.Atleta.AsNoTracking()
                                        .Where(x =>EF.Functions.Like(x.Nome, nome+"%"))
                                        .Include(x => x.Medida)
                                        .Include(x => x.TreinoDia)
                                        .ThenInclude(x => x.Series)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Atleta>> ObterAtletasAsync(int currentPage,int limit)
        {
            return await _context.Atleta.Skip(currentPage)
                                        .Take(limit)            
                                        .AsNoTracking()
                                        .Include(x => x.Medida)
                                        .Include(x => x.TreinoDia)
                                        .ThenInclude(x => x.Series)
                                        .ToListAsync();
        }

        public async Task<int> ObterTotalAtletasAsync()
        {
            return await _context.Atleta.AsNoTracking().CountAsync();
        }
    }
}