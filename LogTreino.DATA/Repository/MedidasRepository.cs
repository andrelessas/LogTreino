using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA.Context;
using LogTreino.DOMAIN;
using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Repository
{
    public class MedidasRepository : IMedidasRepository
    {
        private readonly LogTreinoContext _context;

        public MedidasRepository(LogTreinoContext context)
        {
            _context = context;
        }
        public async Task AlterarMedidaAsync(Medida medida)
        {
            _context.Entry(medida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirMedidaAsync(Medida medida)
        {
            _context.Remove(medida);
            await _context.SaveChangesAsync();
        }

        public async Task InserirMedidaAsync(Medida medida)
        {
            _context.Add(medida);
            await _context.SaveChangesAsync();
        }

        public async Task<Medida> ObterMedidaPorIDAsync(int id)
        {
            return await _context.Medidas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Medida>> ObterMedidasPorAtletaAsync(int idAtleta,Paginacao paginacao)
        {
            return await _context.Medidas.Take(paginacao.CurrentPage)
                                         .Skip(paginacao.Limit)
                                         .Where(x=> x.IdAtleta == idAtleta)
                                         .ToListAsync();
        }

        public async Task<IEnumerable<Medida>> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo, Paginacao paginacao)
        {
            return await _context.Medidas.Take(paginacao.CurrentPage)
                                         .Skip(paginacao.Limit)   
                                         .Where(x => x.IdAtleta == medidasAtletaPorPeriodo.IdAtleta && x.DataMedicao >= medidasAtletaPorPeriodo.DataInicial && x.DataMedicao <= medidasAtletaPorPeriodo.DataFinal)
                                         .ToListAsync();
        }

        public async Task<int> ObterTotalMedidasAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo)
        {
            return await _context.Medidas.AsNoTracking()
                                         .Where(x=>x.IdAtleta == medidasAtletaPorPeriodo.IdAtleta && x.DataMedicao >= medidasAtletaPorPeriodo.DataInicial && x.DataMedicao <= medidasAtletaPorPeriodo.DataFinal)
                                         .CountAsync();
        }

        public async Task<int> ObterTotalMedidasAsync(int idAtleta)
        {
            return await _context.Medidas.AsNoTracking().Where(x=>x.IdAtleta == idAtleta).CountAsync();
        }
    }
}