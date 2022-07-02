using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LogTreino.DATA.Context;
using LogTreino.DOMAIN.Entities;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity,new()
    {
        protected readonly LogTreinoContext _context;
        public Repository(LogTreinoContext context)
        {
            _context = context;
        }
        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync(Paginacao paginacao)
        {
            return await _context.Set<TEntity>().Take(paginacao.Limit)
                                                .Skip(paginacao.CurrentPage)
                                                .AsNoTracking()
                                                .ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<TEntity> ObterPorIDAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task AlterarAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }
        public virtual async Task ExcluirAsync(int id)
        {
            _context.Set<TEntity>().Remove(new TEntity{Id = id});
            await SaveChangesAsync();
        }
        public virtual async Task InserirAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}