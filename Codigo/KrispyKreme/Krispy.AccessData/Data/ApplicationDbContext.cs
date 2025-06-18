using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models.Model;
using Krispy.Models.Model.Catalogs;
using Krispy.Models.Model.Transactional;
using Krispy.Models.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace Krispy.AccessData.Data
{
    public class ApplicationDbContext: DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BDKrispy;Trusted_Connection=True;TrustServerCertificate=True;");

            }
        }


        //Users
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }


        // Catalogs
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EstatusOrden> EstatusOrden { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }

        //Transactional 
        public DbSet<Orden> Orden { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            foreach (var entry in ChangeTracker.Entries<Audita>())
            {
                var userId = _currentUserService?.UserId ?? "system";

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.FechaCreacion = DateTime.UtcNow;
                    entry.Entity.CreadoPor = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.FechaModificacion = DateTime.UtcNow;
                    entry.Entity.ModificadoPor = userId;
                }
            }
            return await base.SaveChangesAsync(ct);
        }
    }
}
