using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.AccessData.Data.Repository.IRepository.Transactional;
using Krispy.AccessData.Data.Repository.IRepository.Users;

namespace Krispy.AccessData.Data.Repository.IRepository
{
    public interface IContent:IDisposable
    {
        //Catalogs
        IClienteRepository Cliente { get; }
        IEstatusOrdenRepository EstatusOrden { get; }
        IMetodoPagoRepository MetodoPago { get; }
        IProductoRepository Producto { get; }
        ISucursalRepository Sucursal { get; }
        ITipoProductoRepository TipoProducto { get; }

        //Transactional
        IDetalleOrdenRepository DetalleOrden { get; }
        IOrdenRepository Orden { get; }

        //Users
        IRolRepository Rol { get; }
        IUsuarioRepository Usuario { get; }
    }
}
