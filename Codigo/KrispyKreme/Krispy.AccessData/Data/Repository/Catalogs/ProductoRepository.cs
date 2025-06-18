using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.Models.Model.Catalogs;

namespace Krispy.AccessData.Data.Repository.Catalogs
{
    public class ProductoRepository:Repository<Producto>,IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
