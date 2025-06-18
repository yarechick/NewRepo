using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.AccessData.Data.Repository.IRepository
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
