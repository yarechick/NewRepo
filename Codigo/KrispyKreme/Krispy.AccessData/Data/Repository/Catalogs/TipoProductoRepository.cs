using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.Models.Model.Catalogs;

namespace Krispy.AccessData.Data.Repository.Catalogs
{
    public class TipoProductoRepository:Repository<TipoProducto>,ITipoProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public TipoProductoRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
