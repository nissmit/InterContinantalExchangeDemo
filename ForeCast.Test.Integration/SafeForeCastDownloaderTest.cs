using ForeCast.Cache;
using ForeCast.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.Test.Integration
{
    public class SafeForeCastDownloaderTest
    {
        SafeForeCastDownloader _sut;
        string folderPath = @"D:\temp";
        string bucketPath = @"s3://noaa-gfs-bdp-pds/.";
        string key = "AKIA5TFQ554XNCD5KHQ5";
        string secret = "P8OEvJHPdKoJuLCkEnLkaOUeTvLl";
        [TestMethod]
        public async Task GetFileTestTwice()
        {
            try
            {
                var accessData = new AccessData
                {
                    Folder = folderPath,
                    Address = bucketPath,
                    AccessKey = key,
                    PrivateKey = secret
                };
                DateTime date = DateTime.Today.AddHours(8);
                var localSut = new SafeForeCastDownloader(new ForeCastDownloader(accessData), new DownloadCache());
                await localSut.DownloadForeCastFile(date);
                await _sut.DownloadForeCastFile(date);
            }
            catch(Exception ex)
            {
                Assert.Fail("error on downloading twice", ex.ToString());
            }
        }

        [TestInitialize]
        public void SetUp()
        {
            var accessData = new AccessData
            {
                Folder = folderPath,
                Address = bucketPath,
                AccessKey = key,
                PrivateKey = secret
            };
            _sut = new SafeForeCastDownloader(new ForeCastDownloader(accessData), new DownloadCache());
        }
    }
}
