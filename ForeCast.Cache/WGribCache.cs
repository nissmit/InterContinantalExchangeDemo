using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCast.Common;

namespace ForeCast.Cache
{
    public class WGribCache : Cache<IRequestData, IForeCastData>,IWgribCache
    {

    }
}
