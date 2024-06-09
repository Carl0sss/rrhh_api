using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Usuario
{
    public string CodUsuario { get; set; } = null!;

    public int? CodRol { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Password { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Role? CodRolNavigation { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<OrdenVenta> OrdenVenta { get; set; } = new List<OrdenVenta>();

    public virtual ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
