using Core.Persistence.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IRepositoryAsync<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.UtcNow;
        }
        await Context.AddAsync(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        await SetEntityDeletedAsync(entity, permanent);
        await Context.SaveChangesAsync();
        return entity;

    }
    public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
    {
        foreach (TEntity entity in entities)
        {
            await SetEntityDeletedAsync(entity, permanent);
        }
        await Context.SaveChangesAsync();
        return entities;
    }

    protected async Task SetEntityDeletedAsync(TEntity entity, bool permanent)
    {
        if (!permanent)
        {
            CheckHasEntityHaveOneToOneRelation(entity);
            entity.DeletedDate = DateTime.Now;
            Context.Update(entity);
        }
        else
        {
            Context.Remove(entity);
        }
    }
    protected void CheckHasEntityHaveOneToOneRelation(TEntity entity)
    {
        IEnumerable<IForeignKey> foreignKeys = Context.Entry(entity).Metadata.GetForeignKeys();
        IForeignKey? oneToOneForeignKey = foreignKeys.FirstOrDefault(fk =>
            fk.IsUnique && fk.PrincipalKey.Properties.All(pk => Context.Entry(entity).Property(pk.Name).Metadata.IsPrimaryKey())
        );

        if (oneToOneForeignKey != null)
        {
            string relatedEntity = oneToOneForeignKey.PrincipalEntityType.ClrType.Name;
            IReadOnlyList<IProperty> primaryKeyProperties = Context.Entry(entity).Metadata.FindPrimaryKey()!.Properties;
            string primaryKeyNames = string.Join(", ", primaryKeyProperties.Select(prop => prop.Name));
            throw new InvalidOperationException(
                $"Entity {entity.GetType().Name} has a one-to-one relationship with {relatedEntity} via the primary key ({primaryKeyNames}). Soft Delete causes problems if you try to create an entry again with the same foreign key."
            );
        }
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, cancellationToken);
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {

        entity.UpdatedDate = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.UpdatedDate = DateTime.UtcNow;
        }
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync();
        return entities;
    }
}
