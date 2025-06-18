using Krispy.AccessData.Data.Repository.Catalogs;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.AccessData.Data.Repository.IRepository.Transactional;
using Krispy.AccessData.Data.Repository.IRepository.Users;
using Krispy.AccessData.Data.Repository.Transactional;
using Krispy.AccessData.Data.Repository.Users;
using Krispy.Models.Model.Transactional;

namespace Krispy.AccessData.Data.Repository
{
    public class Content : IContent
    {
        private readonly ApplicationDbContext _db;

        public Content(ApplicationDbContext db)
        {
            _db = db;

            Cliente = new ClienteRepository(_db);
            EstatusOrden = new EstatusOrdenRepository(_db);
            MetodoPago = new MetodoPagoRepository(_db);
            Producto = new ProductoRepository(_db);
            Sucursal = new SucursalRepository(_db);
            TipoProducto = new TipoProductoRepository(_db);

            DetalleOrden = new DetalleOrdenRepository(_db);
            Orden = new OrdenRepository(_db);

            Rol = new RolRepository(_db);
            Usuario = new UsuarioRepository(_db);

        }

        //Catalogs
        public IClienteRepository Cliente { get; private set; }

        public IEstatusOrdenRepository EstatusOrden { get; private set; }

        public IMetodoPagoRepository MetodoPago { get; private set; }

        public IProductoRepository Producto { get; private set; }

        public ISucursalRepository Sucursal { get; private set; }

        public ITipoProductoRepository TipoProducto { get; private set; }


        //Transactional
        public IDetalleOrdenRepository DetalleOrden { get; private set; }

        public IOrdenRepository Orden { get; private set; }


        //Users
        public IRolRepository Rol { get; private set; }

        public IUsuarioRepository Usuario { get; private set; }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
