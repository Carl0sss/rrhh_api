using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Empleado
{
    public int CodEmpleado { get; set; }

    public int? CodGrupo { get; set; }

    public string? CodPuesto { get; set; }

    public string? CodDepartamento { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Sexo { get; set; }

    public string? Dui { get; set; }

    public string? Isss { get; set; }

    public string? Afp { get; set; }

    public string? NombreAfp { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

    public string? EstadoCivil { get; set; }

    public int? NumeroContrato { get; set; }

    public decimal? Salario { get; set; }

    public string? Email { get; set; }

    public virtual Departamento? CodDepartamentoNavigation { get; set; }

    public virtual HorariosGrupo? CodGrupoNavigation { get; set; }

    public virtual Puesto? CodPuestoNavigation { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
