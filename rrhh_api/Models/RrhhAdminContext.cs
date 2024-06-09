using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace rrhh_api.Models;

public partial class RrhhAdminContext : DbContext
{
    public RrhhAdminContext()
    {
    }

    public RrhhAdminContext(DbContextOptions<RrhhAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }

    public virtual DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }

    public virtual DbSet<DetalleOrdenVenta> DetalleOrdenVenta { get; set; }

    public virtual DbSet<DetallePlanilla> DetallePlanillas { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Famila> Familia { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<HorariosGrupo> HorariosGrupos { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<OrdenVenta> OrdenVenta { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Planilla> Planillas { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; }

    public virtual DbSet<TipoSn> TipoSns { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.CodArticulo)
                .HasName("PK_ARTICULO")
                .IsClustered(false);

            entity.ToTable("Articulo");

            entity.HasIndex(e => e.CodFamilia, "FAMILIA_ARTICULO_FK");

            entity.HasIndex(e => e.CodProveedor, "PROVEEDOR_ARTICULO_FK");

            entity.Property(e => e.CodArticulo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codArticulo");
            entity.Property(e => e.CodFamilia).HasColumnName("codFamilia");
            entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");
            entity.Property(e => e.Compra)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("compra");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Foto)
                .HasColumnType("image")
                .HasColumnName("foto");
            entity.Property(e => e.Medida)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("medida");
            entity.Property(e => e.NombreArticulo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreArticulo");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnitario");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UltimoIngreso)
                .HasColumnType("datetime")
                .HasColumnName("ultimoIngreso");
            entity.Property(e => e.Venta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venta");

            entity.HasOne(d => d.CodFamiliaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.CodFamilia)
                .HasConstraintName("FK_ARTICULO_FAMILIA_A_FAMILIA");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.CodProveedor)
                .HasConstraintName("FK_ARTICULO_PROVEEDOR_PROVEEDO");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente)
                .HasName("PK_CLIENTES")
                .IsClustered(false);

            entity.HasIndex(e => e.CodTipoSn, "CLIENTE_TIPO_FK");

            entity.Property(e => e.CodCliente)
                .ValueGeneratedNever()
                .HasColumnName("codCliente");
            entity.Property(e => e.CodTipoSn).HasColumnName("codTipoSn");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreComercial");
            entity.Property(e => e.Nrc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nrc");
            entity.Property(e => e.PersonaContacto)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("personaContacto");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefonoContacto");

            entity.HasOne(d => d.CodTipoSnNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CodTipoSn)
                .HasConstraintName("FK_CLIENTES_CLIENTE_T_TIPOSN");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.CodCotizacion)
                .HasName("PK_COTIZACION")
                .IsClustered(false);

            entity.ToTable("Cotizacion");

            entity.HasIndex(e => e.CodUsuario, "FIRMA_USUARIO_COTIZACION_FK");

            entity.Property(e => e.CodCotizacion)
                .ValueGeneratedNever()
                .HasColumnName("codCotizacion");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.Detalles)
                .HasColumnType("text")
                .HasColumnName("detalles");
            entity.Property(e => e.FechaDocumento)
                .HasColumnType("datetime")
                .HasColumnName("fechaDocumento");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.Retencion)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("retencion");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_COTIZACI_FIRMA_USU_USUARIOS");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.CodDepartamento)
                .HasName("PK_DEPARTAMENTO")
                .IsClustered(false);

            entity.ToTable("Departamento");

            entity.HasIndex(e => e.CodEmpleado, "JEFE_DEPARTAMENTO2_FK");

            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codDepartamento");
            entity.Property(e => e.CodEmpleado).HasColumnName("codEmpleado");
            entity.Property(e => e.DescripcionDepartamento)
                .HasColumnType("text")
                .HasColumnName("descripcionDepartamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreDepartamento");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.CodEmpleado)
                .HasConstraintName("FK_DEPARTAM_JEFE_DEPA_EMPLEADO");
        });

        modelBuilder.Entity<DetalleCotizacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DetalleCotizacion");

            entity.HasIndex(e => e.CodArticulo, "ARTICULO_COTIZACION_FK");

            entity.HasIndex(e => e.CodCotizacion, "DETALLE_COTIZACION_FK");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codArticulo");
            entity.Property(e => e.CodCotizacion).HasColumnName("codCotizacion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnitario");
            entity.Property(e => e.TotalLinea)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalLinea");

            entity.HasOne(d => d.CodArticuloNavigation).WithMany()
                .HasForeignKey(d => d.CodArticulo)
                .HasConstraintName("FK_DETALLEC_ARTICULO__ARTICULO");

            entity.HasOne(d => d.CodCotizacionNavigation).WithMany()
                .HasForeignKey(d => d.CodCotizacion)
                .HasConstraintName("FK_DETALLEC_DETALLE_C_COTIZACI");
        });

        modelBuilder.Entity<DetalleMovimiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DetalleMovimiento");

            entity.HasIndex(e => e.CodArticulo, "ATICULO_MOVIMIENTO_FK");

            entity.HasIndex(e => e.NumeroDocumento, "DETALLE_MOVIMIENTO_FK");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codArticulo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NumeroDocumento).HasColumnName("numeroDocumento");
            entity.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnitario");

            entity.HasOne(d => d.CodArticuloNavigation).WithMany()
                .HasForeignKey(d => d.CodArticulo)
                .HasConstraintName("FK_DETALLEM_ATICULO_M_ARTICULO");

            entity.HasOne(d => d.NumeroDocumentoNavigation).WithMany()
                .HasForeignKey(d => d.NumeroDocumento)
                .HasConstraintName("FK_DETALLEM_DETALLE_M_MOVIMIEN");
        });

        modelBuilder.Entity<DetalleOrdenVenta>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CodArticulo, "ARTICULO_ORDEN_VENTA_FK");

            entity.HasIndex(e => e.CodOrdenVenta, "DETALLE_ORDEN_VENTA_FK");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codArticulo");
            entity.Property(e => e.CodOrdenVenta).HasColumnName("codOrdenVenta");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnitario");
            entity.Property(e => e.TotalLinea)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalLinea");

            entity.HasOne(d => d.CodArticuloNavigation).WithMany()
                .HasForeignKey(d => d.CodArticulo)
                .HasConstraintName("FK_DETALLEO_ARTICULO__ARTICULO");

            entity.HasOne(d => d.CodOrdenVentaNavigation).WithMany()
                .HasForeignKey(d => d.CodOrdenVenta)
                .HasConstraintName("FK_DETALLEO_DETALLE_O_ORDENVEN");
        });

        modelBuilder.Entity<DetallePlanilla>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DetallePlanilla");

            entity.HasIndex(e => e.NumeroPlanilla, "DETALLE_PLANILLA_FK");

            entity.HasIndex(e => e.CodEmpleado, "EMPLEADO_PLANILLA_FK");

            entity.Property(e => e.AfpEmpleado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("afpEmpleado");
            entity.Property(e => e.AfpPatronal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("afpPatronal");
            entity.Property(e => e.Aguinaldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("aguinaldo");
            entity.Property(e => e.AguinaldoNoGravado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("aguinaldoNoGravado");
            entity.Property(e => e.AguinaldoParaRenta)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("aguinaldoParaRenta");
            entity.Property(e => e.CodEmpleado).HasColumnName("codEmpleado");
            entity.Property(e => e.DiasTrabajados)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("diasTrabajados");
            entity.Property(e => e.FechaCorte)
                .HasColumnType("datetime")
                .HasColumnName("fechaCorte");
            entity.Property(e => e.HorasExtDiurnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("horasExtDiurnas");
            entity.Property(e => e.HorasExtNocturnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("horasExtNocturnas");
            entity.Property(e => e.HorasNocturnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("horasNocturnas");
            entity.Property(e => e.IsssEmpleado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("isssEmpleado");
            entity.Property(e => e.IsssPatronal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("isssPatronal");
            entity.Property(e => e.MontoCotizable)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("montoCotizable");
            entity.Property(e => e.MontoDepositoEmpleado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("montoDepositoEmpleado");
            entity.Property(e => e.MontoPlanillaUnica)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("montoPlanillaUnica");
            entity.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            entity.Property(e => e.NumeroPlanilla).HasColumnName("numeroPlanilla");
            entity.Property(e => e.SalarioMensual)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salarioMensual");
            entity.Property(e => e.Subsidios)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subsidios");
            entity.Property(e => e.TiempoEnEmpresa)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tiempoEnEmpresa");
            entity.Property(e => e.TotalHorasExtDiurnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalHorasExtDiurnas");
            entity.Property(e => e.TotalHorasExtNocturnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalHorasExtNocturnas");
            entity.Property(e => e.TotalHorasNocturnas)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalHorasNocturnas");
            entity.Property(e => e.Vacaciones)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("vacaciones");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany()
                .HasForeignKey(d => d.CodEmpleado)
                .HasConstraintName("FK_DETALLEP_EMPLEADO__EMPLEADO");

            entity.HasOne(d => d.NumeroPlanillaNavigation).WithMany()
                .HasForeignKey(d => d.NumeroPlanilla)
                .HasConstraintName("FK_DETALLEP_DETALLE_P_PLANILLA");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CodArticulo, "ARTICULO_VENTA_FK");

            entity.HasIndex(e => e.CodVenta, "DETALLE_VENTA_FK");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codArticulo");
            entity.Property(e => e.CodVenta).HasColumnName("codVenta");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnitario");
            entity.Property(e => e.TotalLinea)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalLinea");

            entity.HasOne(d => d.CodArticuloNavigation).WithMany()
                .HasForeignKey(d => d.CodArticulo)
                .HasConstraintName("FK_DETALLEV_ARTICULO__ARTICULO");

            entity.HasOne(d => d.CodVentaNavigation).WithMany()
                .HasForeignKey(d => d.CodVenta)
                .HasConstraintName("FK_DETALLEV_DETALLE_V_VENTA");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.CodEmpleado)
                .HasName("PK_EMPLEADOS")
                .IsClustered(false);

            entity.HasIndex(e => e.CodGrupo, "HORARIO_EMPLEADO_FK");

            entity.HasIndex(e => e.CodDepartamento, "JEFE_DEPARTAMENTO_FK");

            entity.HasIndex(e => e.CodPuesto, "PUESTO_EMPLEADO_FK");

            entity.Property(e => e.CodEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("codEmpleado");
            entity.Property(e => e.Afp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("afp");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codDepartamento");
            entity.Property(e => e.CodGrupo).HasColumnName("codGrupo");
            entity.Property(e => e.CodPuesto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codPuesto");
            entity.Property(e => e.Domicilio)
                .HasColumnType("text")
                .HasColumnName("domicilio");
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoCivil");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Isss)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("isss");
            entity.Property(e => e.NombreAfp)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreAfp");
            entity.Property(e => e.Nombres)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroContrato).HasColumnName("numeroContrato");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salario");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CodDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodDepartamento)
                .HasConstraintName("FK_EMPLEADO_JEFE_DEPA_DEPARTAM");

            entity.HasOne(d => d.CodGrupoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodGrupo)
                .HasConstraintName("FK_EMPLEADO_HORARIO_E_HORARIOS");

            entity.HasOne(d => d.CodPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodPuesto)
                .HasConstraintName("FK_EMPLEADO_PUESTO_EM_PUESTOS");
        });

        modelBuilder.Entity<Famila>(entity =>
        {
            entity.HasKey(e => e.CodFamilia)
                .HasName("PK_FAMILIA")
                .IsClustered(false);

            entity.Property(e => e.CodFamilia)
                .ValueGeneratedNever()
                .HasColumnName("codFamilia");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreFamilia)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreFamilia");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CodGrupo, "GRUPOS_HORARIOS_FK");

            entity.Property(e => e.CodGrupo).HasColumnName("codGrupo");
            entity.Property(e => e.Dia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dia");
            entity.Property(e => e.HoraEntreda)
                .HasColumnType("datetime")
                .HasColumnName("horaEntreda");
            entity.Property(e => e.HoraFinAlmuerzo)
                .HasColumnType("datetime")
                .HasColumnName("horaFinAlmuerzo");
            entity.Property(e => e.HoraInicioAlmuerzo)
                .HasColumnType("datetime")
                .HasColumnName("horaInicioAlmuerzo");
            entity.Property(e => e.HoraSalida)
                .HasColumnType("datetime")
                .HasColumnName("horaSalida");
            entity.Property(e => e.NumeroDia).HasColumnName("numeroDia");

            entity.HasOne(d => d.CodGrupoNavigation).WithMany()
                .HasForeignKey(d => d.CodGrupo)
                .HasConstraintName("FK_HORARIOS_GRUPOS_HO_HORARIOS");
        });

        modelBuilder.Entity<HorariosGrupo>(entity =>
        {
            entity.HasKey(e => e.CodGrupo)
                .HasName("PK_HORARIOSGRUPOS")
                .IsClustered(false);

            entity.Property(e => e.CodGrupo)
                .ValueGeneratedNever()
                .HasColumnName("codGrupo");
            entity.Property(e => e.DescripcionGrupo)
                .HasColumnType("text")
                .HasColumnName("descripcionGrupo");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.NumeroDocumento)
                .HasName("PK_MOVIMIENTOS")
                .IsClustered(false);

            entity.HasIndex(e => e.CodUsuario, "FIRMA_USUARIO_MOVIMIENTOS_FK");

            entity.Property(e => e.NumeroDocumento)
                .ValueGeneratedNever()
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.CantidadMovimiento).HasColumnName("cantidadMovimiento");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.FechaDocumento)
                .HasColumnType("datetime")
                .HasColumnName("fechaDocumento");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipoMovimiento");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_MOVIMIEN_FIRMA_USU_USUARIOS");
        });

        modelBuilder.Entity<OrdenVenta>(entity =>
        {
            entity.HasKey(e => e.CodOrdenVenta)
                .HasName("PK_ORDENVENTA")
                .IsClustered(false);

            entity.HasIndex(e => e.CodCotizacion, "COTIZACION_ORDEN_VENTA_FK");

            entity.HasIndex(e => e.CodUsuario, "FIRMA_USUARIO_ORDEN_VENTA_FK");

            entity.Property(e => e.CodOrdenVenta)
                .ValueGeneratedNever()
                .HasColumnName("codOrdenVenta");
            entity.Property(e => e.CodCotizacion).HasColumnName("codCotizacion");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.Detalles)
                .HasColumnType("text")
                .HasColumnName("detalles");
            entity.Property(e => e.FechaDocumento)
                .HasColumnType("datetime")
                .HasColumnName("fechaDocumento");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.Retencion)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("retencion");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.CodCotizacionNavigation).WithMany(p => p.OrdenVenta)
                .HasForeignKey(d => d.CodCotizacion)
                .HasConstraintName("FK_ORDENVEN_COTIZACIO_COTIZACI");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.OrdenVenta)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_ORDENVEN_FIRMA_USU_USUARIOS");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.CodPermiso)
                .HasName("PK_PERMISOS")
                .IsClustered(false);

            entity.HasIndex(e => e.CodRol, "PERMISOS_ROL_FK");

            entity.Property(e => e.CodPermiso).HasColumnName("codPermiso");
            entity.Property(e => e.CodRol).HasColumnName("codRol");
            entity.Property(e => e.DescripcionPermiso)
                .HasColumnType("text")
                .HasColumnName("descripcionPermiso");
            entity.Property(e => e.Menu)
                .HasMaxLength(54)
                .IsUnicode(false)
                .HasColumnName("menu");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombrePermiso");
            entity.Property(e => e.PuedeAgregar).HasColumnName("puedeAgregar");
            entity.Property(e => e.PuedeBorrar).HasColumnName("puedeBorrar");
            entity.Property(e => e.PuedeEditar).HasColumnName("puedeEditar");
            entity.Property(e => e.PuedeVer).HasColumnName("puedeVer");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.CodRol)
                .HasConstraintName("FK_PERMISOS_PERMISOS__ROLES");
        });

        modelBuilder.Entity<Planilla>(entity =>
        {
            entity.HasKey(e => e.NumeroPlanilla)
                .HasName("PK_PLANILLA")
                .IsClustered(false);

            entity.ToTable("Planilla");

            entity.HasIndex(e => e.CodUsuario, "FIRMA_USUARIO_PLANILLA_FK");

            entity.Property(e => e.NumeroPlanilla)
                .ValueGeneratedNever()
                .HasColumnName("numeroPlanilla");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("datetime")
                .HasColumnName("fechaFinal");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.MesPlanilla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mesPlanilla");
            entity.Property(e => e.TotalAguinaldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalAguinaldo");
            entity.Property(e => e.TotalDepositoEmpleado)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalDepositoEmpleado");
            entity.Property(e => e.TotalGravable)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalGravable");
            entity.Property(e => e.TotalPlanillaUnica)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalPlanillaUnica");
            entity.Property(e => e.TotalPuesto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalPuesto");
            entity.Property(e => e.TotalSubsidio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalSubsidio");
            entity.Property(e => e.TotalVacaciones)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalVacaciones");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.Planillas)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_PLANILLA_FIRMA_USU_USUARIOS");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.CodProveedor)
                .HasName("PK_PROVEEDORES")
                .IsClustered(false);

            entity.HasIndex(e => e.CodTipoSn, "PROVEEDOR_TIPO_FK");

            entity.Property(e => e.CodProveedor)
                .ValueGeneratedNever()
                .HasColumnName("codProveedor");
            entity.Property(e => e.CodTipoSn).HasColumnName("codTipoSn");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreComercial");
            entity.Property(e => e.Nrc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nrc");
            entity.Property(e => e.PersonaContacto)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("personaContacto");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefonoContacto");

            entity.HasOne(d => d.CodTipoSnNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.CodTipoSn)
                .HasConstraintName("FK_PROVEEDO_PROVEEDOR_TIPOSN");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.CodPuesto)
                .HasName("PK_PUESTOS")
                .IsClustered(false);

            entity.HasIndex(e => e.CodDepartamento, "PUESTO_DEPARTAMENTO_FK");

            entity.Property(e => e.CodPuesto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codPuesto");
            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("codDepartamento");
            entity.Property(e => e.DescripcionPuesto)
                .HasColumnType("text")
                .HasColumnName("descripcionPuesto");
            entity.Property(e => e.NombrePuesto)
                .HasColumnType("text")
                .HasColumnName("nombrePuesto");

            entity.HasOne(d => d.CodDepartamentoNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.CodDepartamento)
                .HasConstraintName("FK_PUESTOS_PUESTO_DE_DEPARTAM");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.TokenId)
                .HasName("PK_REFRESHTOKEN")
                .IsClustered(false);

            entity.ToTable("RefreshToken");

            entity.HasIndex(e => e.CodUsuario, "USUARIO_TOKEN_FK");

            entity.Property(e => e.TokenId)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("tokenId");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.RefreshToken1)
                .HasMaxLength(512)
                .HasColumnName("refreshToken");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_REFRESHT_USUARIO_T_USUARIOS");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.CodRol)
                .HasName("PK_ROLES")
                .IsClustered(false);

            entity.Property(e => e.CodRol).HasColumnName("codRol");
            entity.Property(e => e.DescripcionRol)
                .HasColumnType("text")
                .HasColumnName("descripcionRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<TipoDocumentoVenta>(entity =>
        {
            entity.HasKey(e => e.CodTipoDoc)
                .HasName("PK_TIPODOCUMENTOVENTA")
                .IsClustered(false);

            entity.Property(e => e.CodTipoDoc)
                .ValueGeneratedNever()
                .HasColumnName("codTipoDoc");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.TipoDocVenta)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("tipoDocVenta");
        });

        modelBuilder.Entity<TipoSn>(entity =>
        {
            entity.HasKey(e => e.CodTipoSn)
                .HasName("PK_TIPOSN")
                .IsClustered(false);

            entity.ToTable("TipoSN");

            entity.Property(e => e.CodTipoSn)
                .ValueGeneratedNever()
                .HasColumnName("codTipoSn");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreTipoSn)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreTipoSn");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodUsuario)
                .HasName("PK_USUARIOS")
                .IsClustered(false);

            entity.HasIndex(e => e.CodRol, "USUARIO_ROL_FK");

            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.CodRol).HasColumnName("codRol");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Password)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodRol)
                .HasConstraintName("FK_USUARIOS_ROL_USUAR_ROLES");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.CodVenta)
                .HasName("PK_VENTA")
                .IsClustered(false);

            entity.HasIndex(e => e.CodUsuario, "FIRMA_USUARIO_VENTA_FK");

            entity.HasIndex(e => e.CodOrdenVenta, "ORDEN_VENTA_FK");

            entity.HasIndex(e => e.CodTipoDoc, "TIPO_DOCUMENTO_FK");

            entity.Property(e => e.CodVenta)
                .ValueGeneratedNever()
                .HasColumnName("codVenta");
            entity.Property(e => e.CodOrdenVenta).HasColumnName("codOrdenVenta");
            entity.Property(e => e.CodTipoDoc).HasColumnName("codTipoDoc");
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codUsuario");
            entity.Property(e => e.Detalles)
                .HasColumnType("text")
                .HasColumnName("detalles");
            entity.Property(e => e.FechaDocumento)
                .HasColumnType("datetime")
                .HasColumnName("fechaDocumento");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.Retencion)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("retencion");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.CodOrdenVentaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodOrdenVenta)
                .HasConstraintName("FK_VENTA_ORDEN_VEN_ORDENVEN");

            entity.HasOne(d => d.CodTipoDocNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodTipoDoc)
                .HasConstraintName("FK_VENTA_TIPO_DOCU_TIPODOCU");

            entity.HasOne(d => d.CodUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodUsuario)
                .HasConstraintName("FK_VENTA_FIRMA_USU_USUARIOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
