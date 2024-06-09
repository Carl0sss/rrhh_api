using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class DetallePlanilla
{
    public int? CodEmpleado { get; set; }

    public int? NumeroPlanilla { get; set; }

    public int NumeroLinea { get; set; }

    public DateTime? FechaCorte { get; set; }

    public decimal? TiempoEnEmpresa { get; set; }

    public decimal? SalarioMensual { get; set; }

    public decimal? DiasTrabajados { get; set; }

    public decimal? HorasExtDiurnas { get; set; }

    public decimal? HorasExtNocturnas { get; set; }

    public decimal? HorasNocturnas { get; set; }

    public decimal? Subsidios { get; set; }

    public decimal? TotalHorasExtDiurnas { get; set; }

    public decimal? TotalHorasExtNocturnas { get; set; }

    public decimal? TotalHorasNocturnas { get; set; }

    public decimal? Vacaciones { get; set; }

    public decimal? Aguinaldo { get; set; }

    public decimal? AguinaldoNoGravado { get; set; }

    public decimal? AguinaldoParaRenta { get; set; }

    public decimal? MontoCotizable { get; set; }

    public decimal? IsssPatronal { get; set; }

    public decimal? IsssEmpleado { get; set; }

    public decimal? AfpPatronal { get; set; }

    public decimal? AfpEmpleado { get; set; }

    public decimal? MontoDepositoEmpleado { get; set; }

    public decimal? MontoPlanillaUnica { get; set; }

    public virtual Empleado? CodEmpleadoNavigation { get; set; }

    public virtual Planilla? NumeroPlanillaNavigation { get; set; }
}
