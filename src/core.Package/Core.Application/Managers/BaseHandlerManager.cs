using AutoMapper;
using Core.Application.Dtos;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

    public BaseHandlerManager(IRepositoryAsync<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<TResponse> DeleteAsync<TResponse>(BaseCommandDto dto, bool permanent, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(predicate: b => b.Id == dto.Id, cancellationToken: cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException($"{typeof(T).Name} not found.");
        }

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
        var entity = await _repository.GetAsync(predicate: b => b.Id == dto.Id, cancellationToken: cancellationToken, enableTracking: false);
        if (entity == null)
        {
            throw new NotFoundException($"{typeof(T).Name} not found.");
        }

        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }

    public async Task<GetListResponse<TResponse>> GetListAsync<TResponse>(BaseListQueryDto dto, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool withDeleted = false, bool enableTracking = false, CancellationToken cancellationToken = default)
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

    public async Task<TResponse> GetAsync<TResponse>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool withDeleted = false, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException($"{typeof(T).Name} not found.");
        }

        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }
}
