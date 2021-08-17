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
    public class ForeCastServiceTest
    {
        ForeCastService _sut;
        string folderPath = @"D:\temp";
        string bucketPath = @"s3://noaa-gfs-bdp-pds/.";
        string key = "AKIA5TFQ554XNCD5KHQ5";
        string secret= "P8OEvJHPdKoJuLCkEnLkaOUeTvLl";
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
            _sut= new ForeCastService(new SafeForeCastDownloader(new ForeCastDownloader(accessData), new DownloadCache()),
               new AdvancedGribExtractor(new GribExtractor(), new WGribCache()));
        }
        [TestMethod]
        public async Task GetTemperatureTest()
        {
            DateTime date = DateTime.Parse("17-August-2021 11:00");
            var value = await _sut.GetForeCastData(date, 32.0745, 34.79213);
            Assert.AreEqual(value.Temperature.ToCelsius(), 30, 1.0, "Bad temperature");
        }
    }
}
