using Lab13_BernieOrtiz.Domain.Interfaces;
using Lab13_BernieOrtiz.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab13_BernieOrtiz.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly ControlCashDbContext _context;

    public object Usuarios { get; }

    public UnitOfWork(ControlCashDbContext context) {
        _context = context;
        Usuarios = new GenericRepository<Usuario>(context) as object;
    }

    public async Task<int> CommitAsync() {
        return await _context.SaveChangesAsync();
    }
}
