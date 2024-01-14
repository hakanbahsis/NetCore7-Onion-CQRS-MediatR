﻿namespace Api.Persistance.Repositories;
public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table { get => _context.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(()=>Table.Update(entity));
        return entity;
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(()=>Table.Remove(entity));
    }

    public Task SoftDeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    
}

