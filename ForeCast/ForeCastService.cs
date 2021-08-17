using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCast.Cache;
using ForeCast.Common;

namespace ForeCast
{
    public class ForeCastService:IForeCastService
    {
       
        private IForeCastDownloader _foreCastDownloader;
        private IGribExtractor _gribExtractor;
        
        public ForeCastService(IForeCastDownloader foreCastDownloader,IGribExtractor gribExtractor)
        {
            if (foreCastDownloader == null) throw new ArgumentNullException(nameof(foreCastDownloader));
            if (gribExtractor == null) throw new ArgumentNullException(nameof(gribExtractor));
            _foreCastDownloader = foreCastDownloader;
            _gribExtractor = gribExtractor;
        }

        public async Task<IForeCastData> GetForeCastData(DateTime date, double lat, double lon)
        {
            var request = new RequestData(date) { Latitude = lat, Longitude = lon};
            var fileName= await _foreCastDownloader.DownloadForeCastFile(request.Date);
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("Download failure");
            return await _gribExtractor.ExtractForeCastData(fileName, request);
        }
    }
}
