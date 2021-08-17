using ForeCast.API;
using ForeCast.Cache;
using ForeCast.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast
{
    public class ForeCastServiceFactory : IForeCastServiceFactory
    {
        public IForeCastService CreateForeCastService(IAccessData accessData,IDownloadCache downloadCache, IWgribCache gribCache)
        {
            if (downloadCache == null) throw new ArgumentNullException(nameof(downloadCache));
            if (gribCache == null) throw new ArgumentNullException(nameof(gribCache));
            if (accessData == null) throw new ArgumentNullException(nameof(accessData));
            if (!Directory.Exists(accessData.Folder))
            {
                Directory.CreateDirectory(accessData.Folder);
            }
            return new ForeCastService(new SafeForeCastDownloader(new ForeCastDownloader(accessData), downloadCache),
                new AdvancedGribExtractor(new GribExtractor(), gribCache));
        }
    }
}
