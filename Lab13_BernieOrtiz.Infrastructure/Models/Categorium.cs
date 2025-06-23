using System;
using System.Collections.Generic;

namespace Lab13_BernieOrtiz.Infrastructure.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public int IdUsuario { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
