using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class HorariosGrupo
{
    public int CodGrupo { get; set; }

    public string? DescripcionGrupo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
