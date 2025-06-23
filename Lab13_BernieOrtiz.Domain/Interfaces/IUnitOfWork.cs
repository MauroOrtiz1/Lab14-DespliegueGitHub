namespace Lab13_BernieOrtiz.Domain.Interfaces;

public interface IUnitOfWork
{
    object Usuarios { get; }

    Task<int> CommitAsync();
}