using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.Models.Model.Catalogs;

namespace Krispy.AccessData.Data.Repository.Catalogs
{
    public class SucursalRepository:Repository<Sucursal>,ISucursalRepository
    {
        private readonly ApplicationDbContext _db;
        public SucursalRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
