using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ForeCast.API;

namespace ForeCast.Cache
{
    public class DownloadCache:Cache<string,Mutex>,IDownloadCache
    {
    }
}
