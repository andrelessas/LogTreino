using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA.Context;
using LogTreino.DOMAIN;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Repository
{
    public class TreinoDiaRepository : Repository<TreinoDia>, ITreinoDiaRepository
    {
        public TreinoDiaRepository(LogTreinoContext context)
            :base(context)
        {
            
        }
        public async Task<int> ObterTotalTreinoDias(int idAtleta)
        {
            return await _context.TreinoDia.AsNoTracking().Where(x => x.IdAtleta == idAtleta).CountAsync();
        }
        public async Task<int> ObterTotalTreinoDias(DateTime dataInicial, DateTime dataFinal)
        {
            return await _context.TreinoDia.AsNoTracking()
                                           .Where(x => x.Data >= dataInicial && x.Data <= dataFinal)
                                           .CountAsync();
        }
        public async Task<IEnumerable<TreinoDia>> ObterTreinosPorAtleta(int idAtleta,Paginacao paginacao)
        {
            return await _context.TreinoDia.Skip(paginacao.CurrentPage)
                                           .Take(paginacao.Limit) 
                                           .AsNoTracking()
                                           .Include(x => x.Series)
                                           .Where(x => x.IdAtleta == idAtleta)
                                           .ToListAsync();
        }

        public async Task<IEnumerable<TreinoDia>> ObterTreinosPorPeriodo(DateTime dataInicial, DateTime dataFinal,Paginacao paginacao)
        {
            return await _context.TreinoDia.Skip(paginacao.CurrentPage)
                                           .Take(paginacao.Limit)
                                           .AsNoTracking()
                                           .Include(x => x.Series)
                                           .Where(x => x.Data >= dataInicial && x.Data <= dataFinal)
                                           .ToListAsync();
        }
    }
}