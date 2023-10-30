﻿using Domain.Entities.CoreService;
using Infrastructure.EntityFramework.CoreService;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions.CoreService;
using Services.Repositories.Abstractions.CoreService;
using System.Linq.Expressions;
namespace Infrastructure.Repositories.Implementations.MicroServiceCore.Repositories;

public class EFGenericRepository<TEntity> : IEFGenericRepository<TEntity> where TEntity : class, IEntityId
{
    private readonly CoreServiceDBContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public EFGenericRepository(CoreServiceDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }
    public async Task<TEntity> FindByIdAsync(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(TEntity item)
    {

        await using var tran = await _context.Database.BeginTransactionAsync();
        try
        {
            await _dbSet.AddAsync(item);
            _ = await _context.SaveChangesAsync();
            await tran.CommitAsync();
        }
        catch (Exception ex)
        {
            await tran.RollbackAsync();
            throw new DataOperationException(ExceptionConstants.CreateDataExceptionMessage, ex);
        }
    }
    public async Task UpdateAsync(TEntity item)
    {
        await using var tran = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Entry(item).State = EntityState.Modified;
            _ = await _context.SaveChangesAsync();
            await tran.CommitAsync();
        }
        catch (Exception ex)
        {
            await tran.RollbackAsync();
            throw new DataOperationException(ExceptionConstants.UpdateDataExceptionMessage, ex);
        }
    }
    public async Task RemoveAsync(TEntity item)
    {
        await using var tran = await _context.Database.BeginTransactionAsync();
        try
        {
            _dbSet.Remove(item);
            _ = await _context.SaveChangesAsync();
            await tran.CommitAsync();
        }
        catch (Exception ex)
        {
            await tran.RollbackAsync();
            throw new DataOperationException(ExceptionConstants.RemoveDataExceptionMessage, ex);
        }
    }
}