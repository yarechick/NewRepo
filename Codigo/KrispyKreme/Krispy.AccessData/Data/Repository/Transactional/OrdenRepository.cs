using Krispy.AccessData.Data.Repository.IRepository.Transactional;
using Krispy.Models.Model.Transactional;
using System.Threading.Tasks;

namespace Krispy.AccessData.Data.Repository.Transactional
{
    public class OrdenRepository:Repository<Orden>,IOrdenRepository
    {
        private readonly ApplicationDbContext _db;
        public OrdenRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }

        public Orden Procesar(Orden orden)
        {
            using var transaccion = _db.Database.BeginTransaction();

            try
            {
                _db.Orden.Add(orden);
                _db.SaveChanges();

                transaccion.Commit();

                return orden;

            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw;
            }
        }
    }
}
