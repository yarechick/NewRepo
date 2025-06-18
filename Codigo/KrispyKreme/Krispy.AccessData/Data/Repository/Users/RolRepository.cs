using Krispy.AccessData.Data.Repository.IRepository.Users;
using Krispy.Models.Model.Users;

namespace Krispy.AccessData.Data.Repository.Users
{
    public class RolRepository: Repository<Rol>,IRolRepository
    {
        private readonly ApplicationDbContext _db;
        public RolRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
