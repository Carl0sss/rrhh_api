using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Horario
{
    public int? CodGrupo { get; set; }

    public int? NumeroDia { get; set; }

    public string? Dia { get; set; }

    public DateTime? HoraEntreda { get; set; }

    public DateTime? HoraInicioAlmuerzo { get; set; }

    public DateTime? HoraFinAlmuerzo { get; set; }

    public DateTime? HoraSalida { get; set; }

    public virtual HorariosGrupo? CodGrupoNavigation { get; set; }
}
