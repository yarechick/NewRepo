using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.AccessData.Data.Initializer.Initializer
{
    public interface IInitializerDb
    {
        void MigrateAndSeed();
    }
}
