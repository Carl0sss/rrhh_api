using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Planilla
{
    public int NumeroPlanilla { get; set; }

    public string? CodUsuario { get; set; }

    public string? MesPlanilla { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinal { get; set; }

    public string? Descripcion { get; set; }

    public decimal? TotalPuesto { get; set; }

    public decimal? TotalSubsidio { get; set; }

    public decimal? TotalVacaciones { get; set; }

    public decimal? TotalAguinaldo { get; set; }

    public decimal? TotalGravable { get; set; }

    public decimal? TotalDepositoEmpleado { get; set; }

    public decimal? TotalPlanillaUnica { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }
}
