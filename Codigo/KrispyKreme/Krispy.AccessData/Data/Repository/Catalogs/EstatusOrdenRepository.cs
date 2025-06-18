using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.Models.Model.Catalogs;

namespace Krispy.AccessData.Data.Repository.Catalogs
{
    public class EstatusOrdenRepository:Repository<EstatusOrden>,IEstatusOrdenRepository
    {
        private readonly ApplicationDbContext _db;
        public EstatusOrdenRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
