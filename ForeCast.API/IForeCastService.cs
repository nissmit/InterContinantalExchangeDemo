using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeCast.Common;

namespace ForeCast.API
{
    public interface IForeCastService
    {
        Task<IForeCastData> GetForeCastData(DateTime date, double lat, double lon);
    }
}
