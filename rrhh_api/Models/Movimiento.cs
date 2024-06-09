using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Movimiento
{
    public int NumeroDocumento { get; set; }

    public string? CodUsuario { get; set; }

    public DateTime? FechaDocumento { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? CantidadMovimiento { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }
}
