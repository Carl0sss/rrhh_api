using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Puesto
{
    public string CodPuesto { get; set; } = null!;

    public string? CodDepartamento { get; set; }

    public string? NombrePuesto { get; set; }

    public string? DescripcionPuesto { get; set; }

    public virtual Departamento? CodDepartamentoNavigation { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
