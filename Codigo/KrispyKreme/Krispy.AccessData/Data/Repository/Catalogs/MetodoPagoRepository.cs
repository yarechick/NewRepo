using Krispy.AccessData.Data.Repository.IRepository.Catalogs;
using Krispy.Models.Model.Catalogs;

namespace Krispy.AccessData.Data.Repository.Catalogs
{
    public class MetodoPagoRepository:Repository<MetodoPago>,IMetodoPagoRepository
    {
        private readonly ApplicationDbContext _db;
        public MetodoPagoRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
