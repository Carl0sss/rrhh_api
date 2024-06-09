using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Role
{
    public int CodRol { get; set; }

    public string? NombreRol { get; set; }

    public string? DescripcionRol { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
