using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.API
{
    public interface IForeCastDownloader
    {
        Task<string> DownloadForeCastFile(DateTime date);
        string GetFileName(DateTime date);
        bool DownloadSucceed(DateTime date);
    }
}
