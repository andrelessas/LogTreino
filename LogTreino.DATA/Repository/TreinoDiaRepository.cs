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
    public class TreinoDiaRepository : ITreinoDiaRepository
    {
        private readonly LogTreinoContext _context;

        public TreinoDiaRepository(LogTreinoContext context)
        {
            _context = context;
        }
        public async Task AlterarTreinoDiaAsync(TreinoDia treinoDia)
        {
            _context.Entry(treinoDia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirTreinoDiaAsync(TreinoDia treinoDia)
        {
            _context.Remove(treinoDia);
            await _context.SaveChangesAsync();
        }

        public async Task InserirTreinoDiaAsync(TreinoDia treinoDia)
        {
            _context.Add(treinoDia);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ObterTotalTreinoDias(int idAtleta)
        {
            return await _context.TreinoDia.AsNoTracking().Where(x => x.IdAtleta == idAtleta).CountAsync();
        }
        public async Task<int> ObterTotalTreinoDias(DateTime data)
        {
            return await _context.TreinoDia.AsNoTracking().Where(x => x.Data == data).CountAsync();
        }

        public async Task<TreinoDia> ObterTreinoDiaPorID(int id)
        {
            return await _context.TreinoDia.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TreinoDia>> ObterTreinosPorAtleta(TreinoDia treinoDia,Paginacao paginacao)
        {
            return await _context.TreinoDia.Skip(paginacao.CurrentPage)
                                           .Take(paginacao.Limit) 
                                           .AsNoTracking()
                                           .Include(x => x.Series)
                                           .Where(x => x.IdAtleta == treinoDia.IdAtleta)
                                           .ToListAsync();
        }

        public async Task<IEnumerable<TreinoDia>> ObterTreinosPorData(TreinoDia treinoDia,Paginacao paginacao)
        {
            return await _context.TreinoDia.Skip(paginacao.CurrentPage)
                                           .Take(paginacao.Limit)
                                           .AsNoTracking()
                                           .Include(x => x.Series)
                                           .Where(x => x.Data == treinoDia.Data)
                                           .ToListAsync();
        }
    }
}