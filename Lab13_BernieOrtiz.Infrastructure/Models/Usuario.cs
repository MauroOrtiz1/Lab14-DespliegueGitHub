using System;
using System.Collections.Generic;

namespace Lab13_BernieOrtiz.Infrastructure.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? EsPremium { get; set; }

    public bool? AnunciosActivos { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();

    public virtual ICollection<Exportacion> Exportacions { get; set; } = new List<Exportacion>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
