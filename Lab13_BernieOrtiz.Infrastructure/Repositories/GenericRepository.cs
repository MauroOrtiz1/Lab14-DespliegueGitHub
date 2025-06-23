using Lab13_BernieOrtiz.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab13_BernieOrtiz.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    public GenericRepository(DbContext context) => _context = context;

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}
