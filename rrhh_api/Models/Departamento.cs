using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Departamento
{
    public string CodDepartamento { get; set; } = null!;

    public int? CodEmpleado { get; set; }

    public string? NombreDepartamento { get; set; }

    public string? DescripcionDepartamento { get; set; }

    public virtual Empleado? CodEmpleadoNavigation { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
