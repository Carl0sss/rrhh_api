namespace rrhh_api.Dto
{
    public class EmpleadoDto
    {
        public int CodEmpleado { get; set; }

        public int? CodGrupo { get; set; }

        public string? Puesto { get; set; }

        public string? Departamento { get; set; }

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
    }
}
