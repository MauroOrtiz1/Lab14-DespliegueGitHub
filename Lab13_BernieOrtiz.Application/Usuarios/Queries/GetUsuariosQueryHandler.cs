using Lab13_BernieOrtiz.Application.Usuarios.DTOs;
using Lab13_BernieOrtiz.Domain.Interfaces;

namespace Lab13_BernieOrtiz.Application.Usuarios.Queries;

public class GetUsuariosQueryHandler
{
    private readonly IUnitOfWork _uow;

    public GetUsuariosQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<UsuarioDto>> Handle(GetUsuariosQuery query)
    {
        dynamic repo = _uow.Usuarios;
        var usuariosEf = (IEnumerable<dynamic>)await repo.GetAllAsync();

        return usuariosEf.Select(u => new UsuarioDto
        {
            IdUsuario = u.IdUsuario,
            Nombre = u.Nombre,
            Email = u.Email
        });
    }


}