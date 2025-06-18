using Krispy.Models.Model.Transactional;

namespace Krispy.AccessData.Data.Repository.IRepository.Transactional
{
    public interface IOrdenRepository:IRepository<Orden>
    {
        Orden Procesar(Orden orden);
    }
}
