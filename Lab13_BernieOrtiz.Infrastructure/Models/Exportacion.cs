using System;
using System.Collections.Generic;

namespace Lab13_BernieOrtiz.Infrastructure.Models;

public partial class Exportacion
{
    public int IdExportacion { get; set; }

    public int IdUsuario { get; set; }

    public string TipoArchivo { get; set; } = null!;

    public string? OrigenGrafico { get; set; }

    public DateTime? FechaExportado { get; set; }

    public int? MesExportado { get; set; }

    public int? AnioExportado { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
