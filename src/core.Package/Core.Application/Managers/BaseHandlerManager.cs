using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Entities;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

    public async Task<GetListResponse<TResponse>> GetListAsync<TResponse>(BaseListQueryDto dto, CancellationToken cancellationToken)
    {
        Paginate<T> entites = await _repository.GetListAsync(index: dto.PageRequest.PageIndex, size: dto.PageRequest.PageSize, cancellationToken: cancellationToken);

        GetListResponse<TResponse> response = _mapper.Map<GetListResponse<TResponse>>(entites);
        return response;
    }

    public async Task<TResponse> GetAsync<TResponse>(BaseQueryDto dto, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(predicate: b => b.Id == dto.Id, cancellationToken: cancellationToken);
        TResponse response = _mapper.Map<TResponse>(entity);
        return response;
    }
}
