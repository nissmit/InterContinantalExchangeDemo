using System;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCast.Common;

namespace ForeCast
{
    public class AdvancedGribExtractor : IGribExtractor
    {
        private readonly IGribExtractor _gribExtractor;
        private readonly IWgribCache _cache;
        public AdvancedGribExtractor(IGribExtractor gribExtractor, IWgribCache cache)
        {
            if (gribExtractor == null) throw new ArgumentNullException(nameof(gribExtractor));
            if (cache == null) throw new ArgumentNullException(nameof(cache));
            _gribExtractor = gribExtractor;
            _cache = cache;
        }

        public async Task<IForeCastData> ExtractForeCastData(string fileName, IRequestData request)
        {
            if (_cache.Contains(request))
                return await Task.FromResult(_cache.GetValue(request));
            var task = await _gribExtractor.ExtractForeCastData(fileName, request);
            _cache.AddValue(request, task);
            return task;
        }
    }
}
