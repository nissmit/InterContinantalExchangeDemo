using ForeCast.Common;

namespace ForeCast.API
{
    public interface IForeCastServiceFactory
    {
        IForeCastService CreateForeCastService(IAccessData accessData, IDownloadCache downloadCache, IWgribCache gribCache);
    }
}
