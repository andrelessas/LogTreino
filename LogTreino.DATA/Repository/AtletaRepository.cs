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
    public class AtletaRepository:IAtletaRepository
    {
        private readonly LogTreinoContext _context;

        public AtletaRepository(LogTreinoContext context)
        {
            _context = context;
        }

        public async Task AlterarAtletaAsync(Atleta atleta)
        {
            _context.Entry(atleta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAtletaAsync(Atleta atleta, int id)
        {
            _context.Remove(atleta);
            await _context.SaveChangesAsync();
        }

        public async Task InserirAtletaAsync(Atleta atleta)
        {
            _context.Add(atleta);
            await _context.SaveChangesAsync();
        }

        public async Task<Atleta> ObterAtletaAsync(int id)
        {
            return await _context.Atleta.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Atleta>> ObterAtletasAsync(int currentPage,int limit)
        {
            return await _context.Atleta.Skip(currentPage).Take(limit).AsNoTracking().ToListAsync();
        }

        public async Task<int> ObterTotalAtletasAsync()
        {
            return await _context.Atleta.AsNoTracking().CountAsync();
        }
    }
}