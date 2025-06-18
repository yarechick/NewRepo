using Krispy.AccessData.Data.Repository.IRepository.Transactional;
using Krispy.Models.Model.Transactional;

namespace Krispy.AccessData.Data.Repository.Transactional
{
    public class DetalleOrdenRepository:Repository<DetalleOrden>,IDetalleOrdenRepository
    {
        private readonly ApplicationDbContext _db;
        public DetalleOrdenRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
