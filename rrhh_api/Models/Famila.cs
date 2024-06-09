using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Famila
{
    public int CodFamilia { get; set; }

    public string? NombreFamilia { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
