using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Entities;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Core.Application.Managers;

public class BaseHandlerManager<T> where T : Entity
{
    public IRepositoryAsync<T> _repository;
    public IMapper _mapper;
    public Expression<Func<T, bool>> predicate = x => x.Id != null;
    public Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null;
    public Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null;
    public BaseHandlerManager(IRepositoryAsync<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<TResponse> DeleteAsync<TResponse>(BaseCommandDto dto, bool permanent, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(predicate: b => b.Id == dto.Id, cancellationToken: cancellationToken);
        await _repository.DeleteAsync(entity, permanent);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }

    public async Task<TResponse> CreateAsync<TResponse>(BaseCommandDto dto, CancellationToken cancellationToken)
    {
        T entity = _mapper.Map<T>(dto);
        await _repository.AddAsync(entity);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }

    public async Task<TResponse> UpdateAsync<TResponse>(BaseCommandDto dto, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(predicate: b => b.Id == dto.Id, cancellationToken: cancellationToken);
        entity = _mapper.Map<T>(dto);
        await _repository.UpdateAsync(entity);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }

    public async Task<GetListResponse<TResponse>> GetListAsync<TResponse>(BaseListQueryDto dto, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        Paginate<T> entites = await _repository.GetListAsync(predicate: predicate,
                                                             orderBy: orderBy,
                                                             include: include,
                                                             withDeleted: withDeleted,
                                                             enableTracking: enableTracking,
                                                             index: dto.PageIndex,
                                                             size: dto.PageSize,
                                                             cancellationToken: cancellationToken);

        GetListResponse<TResponse> response = _mapper.Map<GetListResponse<TResponse>>(entites);
        return response;
    }

    public async Task<TResponse> GetAsync<TResponse>(bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }
}
