using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Permiso
{
    public int CodPermiso { get; set; }

    public int? CodRol { get; set; }

    public string? NombrePermiso { get; set; }

    public string? DescripcionPermiso { get; set; }

    public string? Menu { get; set; }

    public bool? PuedeVer { get; set; }

    public bool? PuedeEditar { get; set; }

    public bool? PuedeAgregar { get; set; }

    public bool? PuedeBorrar { get; set; }

    public virtual Role? CodRolNavigation { get; set; }
}
