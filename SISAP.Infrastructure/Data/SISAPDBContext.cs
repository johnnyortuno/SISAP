using SISAP.Core.Entities;
using SISAP.Infrastructure.Data.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SISAP.Infrastructure.Data
{
    public class SISAPDBContext : DbContext
    {
        public SISAPDBContext() : base("SISAPDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SISAPDBContext>());
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new FacturacionConfiguration());
            modelBuilder.Configurations.Add(new TarifarioConfiguration());
            modelBuilder.Configurations.Add(new MesesConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new OpcionConfiguracion());
            modelBuilder.Configurations.Add(new OpcionUsuarioConfiguracion());
            modelBuilder.Configurations.Add(new UrbanizacionConfiguration());
            modelBuilder.Configurations.Add(new TipoCategoriaConfiguration());
            modelBuilder.Configurations.Add(new ServicioConfiguration());
            modelBuilder.Configurations.Add(new PagoConfiguration());
            modelBuilder.Configurations.Add(new MedidorConfiguration());
            modelBuilder.Configurations.Add(new LecturaConfiguration());
            modelBuilder.Configurations.Add(new ManzanaConfiguration());
            modelBuilder.Configurations.Add(new FacturaConfiguration());
            modelBuilder.Configurations.Add(new EstadoPagoConfiguration());
            modelBuilder.Configurations.Add(new EstadoServicioConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new DireccionDatoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DetalleFacturaConfiguration());
            modelBuilder.Configurations.Add(new DetalleEstadoPagoConfiguration());
            modelBuilder.Configurations.Add(new ConsumoServicioConfiguration());
            modelBuilder.Configurations.Add(new CiclosConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());

        }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Facturacion> Facturacions { get; set; }
        public DbSet<Urbanizacion> Urbanizacions { get; set; }
        public DbSet<Tarifario> Tarifarios { get; set; }
        public DbSet<Meses> Meses { get; set; }
        public DbSet<TipoCategoria> TipoCategorias { get; set; }
        public DbSet<Servicio> servicios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Medidor> Medidors { get; set; }
        public DbSet<Lectura> Lecturas { get; set; }
        public DbSet<Manzana> Manzanas{ get; set; }
        public DbSet<EstadoPago> EstadoPagos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoServicio> EstadoServicios{ get; set; }
        public DbSet<DireccionDato> DireccionDatos { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<DetalleEstadoPago> DetalleEstadoPagos { get; set; }
        public DbSet<ConsumoServicio> ConsumoServicios { get; set; }
        public DbSet<Ciclos> Ciclos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Opcion> Opcions { get; set; }
        public DbSet<OpcionUsuario> OpcionUsuarios { get; set; }
    }
}
