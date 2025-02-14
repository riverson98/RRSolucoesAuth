using AutoMapper;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class Service<TEntity, TDto> : IService<TEntity,TDto>
                                      where TEntity : class
                                      where TDto : class
{
    private IUnityOfWork<TEntity> _unityOfWork;
    private readonly IMapper _mapper;

    public Service(IUnityOfWork<TEntity> unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<TDto> Add(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var EntityAdded = _unityOfWork.Repository.Add(entity);
        await _unityOfWork.CommitAsync();

        var dtoCreated = _mapper.Map<TDto>(EntityAdded);
        return dtoCreated;
    }

    public async Task Delete(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        
        _unityOfWork.Repository.Delete(entity);
        await _unityOfWork.CommitAsync();
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entites = await _unityOfWork.Repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entites);
    }

    public async Task<TDto?> GetAsync(Expression<Func<TDto, bool>> predicate)
    {
        var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
        var entity = await _unityOfWork.Repository.GetAsync(entityPredicate);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Update(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var entityUpdated = _unityOfWork.Repository.Update(entity);
        await _unityOfWork.CommitAsync();

        var dtoUpdated = _mapper.Map<TDto>(entityUpdated);
        return dtoUpdated;
    }
}
