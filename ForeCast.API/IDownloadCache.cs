using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForeCast.API
{
    public interface IDownloadCache:ICache<string,Mutex>
    {
    }
}
