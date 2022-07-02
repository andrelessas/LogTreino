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
    public class MedidasRepository : Repository<Medida>, IMedidasRepository
    {      
        public async Task<IEnumerable<Medida>> ObterMedidasPorAtletaAsync(int idAtleta,Paginacao paginacao)
        {
            return await _context.Medidas.Skip(paginacao.CurrentPage) 
                                         .Take(paginacao.Limit)
                                         .Where(x=> x.IdAtleta == idAtleta)
                                         .ToListAsync();
        }

        public async Task<IEnumerable<Medida>> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo, Paginacao paginacao)
        {
            return await _context.Medidas.Skip(paginacao.CurrentPage) 
                                         .Take(paginacao.Limit) 
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