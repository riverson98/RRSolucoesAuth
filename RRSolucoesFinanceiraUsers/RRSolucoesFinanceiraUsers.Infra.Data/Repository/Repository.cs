using Microsoft.EntityFrameworkCore;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDBContext _context;

    public Repository(ApplicationDBContext context)
    {
        _context = context;
    }

    public T Add(T entity)
    {
        _context.Add(entity);
        return entity;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
}
