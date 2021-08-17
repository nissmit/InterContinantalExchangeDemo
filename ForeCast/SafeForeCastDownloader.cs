using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCast.Cache;
using ForeCast.Common;

namespace ForeCast
{
    public class SafeForeCastDownloader:IForeCastDownloader
    {
        private readonly IForeCastDownloader _foreCastDownloader;
        private static Mutex globalMutex = new Mutex();
        private readonly IDownloadCache _downloadCache;
        public SafeForeCastDownloader(IForeCastDownloader foreCastDownloader,IDownloadCache downloadCache)
        {
            if (foreCastDownloader == null) throw new ArgumentNullException(nameof(foreCastDownloader));
            if (downloadCache == null) throw new ArgumentNullException(nameof(downloadCache));
            _foreCastDownloader = foreCastDownloader;
            _downloadCache = downloadCache;
        }

        public async Task<string> DownloadForeCastFile(DateTime date)
        {
            var fileName = _foreCastDownloader.GetFileName(date);
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                return fileName;

            var fileMutex = new Mutex();
            globalMutex.WaitOne();
            if (!_downloadCache.Contains(fileName))
            {
                _downloadCache.AddValue(fileName, fileMutex);
            }
            globalMutex.ReleaseMutex();
            fileMutex = _downloadCache.GetValue(fileName);
            try
            {
                fileMutex.WaitOne();
                return await _foreCastDownloader.DownloadForeCastFile(date);
                
            }
            finally
            {
                if(_foreCastDownloader.DownloadSucceed(date))
                    _downloadCache.RemoveValue(fileName);
                fileMutex.ReleaseMutex();
            }
        }

        public string GetFileName(DateTime date)
        {
            return _foreCastDownloader.GetFileName(date);
        }

        public bool DownloadSucceed(DateTime date)
        {
            return _foreCastDownloader.DownloadSucceed(date);
        }
    }
}
