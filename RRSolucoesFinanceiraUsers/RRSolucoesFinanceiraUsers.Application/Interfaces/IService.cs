using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IService<TEntity, TDto>
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetAsync(Expression<Func<TDto, bool>> predicate);
    Task<TDto> Add(TDto dto);
    Task<TDto> Update(TDto dto);
    Task Delete(TDto dto);
}
