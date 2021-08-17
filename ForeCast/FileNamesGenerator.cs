using ForeCast.API;
using System;

namespace ForeCast
{
    public class FileNamesGenerator: IFileNamesGenerator
    {
        private const string GFS_PREFIX = "gfs.t00z.pgrb2.0p25.f";
        private const string GFS_FOLDER = "/00/atmos/";
        public (string File, string Bucket) CreateFileNames(DateTime date)
        {
            if (date.Date > DateTime.Today)
            {
                double hours = date.Date.Subtract(DateTime.Today).TotalHours;
                if (hours > 120)
                    throw new InvalidOperationException("No data yet");
                return (File: $"{DateTime.Today.ToString("yyyMMdd")}-{hours.ToString("HH")}", Bucket: BucketFilePath(DateTime.Today.ToString("yyyyMMdd"), Convert.ToInt32(hours)));
            }
            return (File: $"{date.ToString("yyyyMMdd")}.{GFS_PREFIX}{date.ToString("HH")}", Bucket: BucketFilePath(date.ToString("yyyyMMdd"), date.Hour));
        }

        private string BucketFilePath(string date, int offset)
        {
            return $"gfs.{date}{GFS_FOLDER}{GFS_PREFIX}{offset.ToString("000")}";
        }
    }
}
