using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LogTreino.DOMAIN.Entities;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
        Task InserirAsync(TEntity entity);
        Task AlterarAsync(TEntity entity);
        Task ExcluirAsync(int id);
        Task<TEntity> ObterPorIDAsync(int id);
        Task<IEnumerable<TEntity>> ObterTodosAsync(Paginacao paginacao);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity,bool>> condicao);
        Task<int> SaveChangesAsync();
    }
}