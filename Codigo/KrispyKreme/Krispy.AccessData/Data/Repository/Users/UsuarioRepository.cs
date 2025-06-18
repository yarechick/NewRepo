using Krispy.AccessData.Data.Repository.IRepository.Users;
using Krispy.Models.Model.Users;

namespace Krispy.AccessData.Data.Repository.Users
{
    public class UsuarioRepository:Repository<Usuario>,IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        public UsuarioRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _db = contexto;
        }
    }
}
