using ForeCast.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ForeCast.Test.Unit
{
    [TestClass]
    public class ForeCastDownloaderTest
    {
        ForeCastDownloader _sut;
        
        [TestMethod]
        public void GetNextFileNameTest()
        {
            try
            {
                _sut.GetFileName(DateTime.Now.AddDays(6));
                Assert.Fail("Dont need to work");
            }
            catch(InvalidOperationException)
            {
            }
            catch(Exception)
            {
                Assert.Fail("Need to throw another exception");
            }
        }

        [TestMethod]
        public void GetFileTest()
        {
            DateTime date = DateTime.Parse("17-August-2021 11:00");
            var result =_sut.DownloadForeCastFile(date).Result;
            Assert.IsTrue(File.Exists(result), "File not downloaded");
            Assert.AreEqual(result, _sut.GetFileName(date),"Bad name file generation");
           
        }
      

        [TestInitialize]
        public void SetUp()
        {
            string folderPath = @"D:\temp";
            string bucketPath = @"s3://noaa-gfs-bdp-pds/.";
            string key = "AKIA5TFQ554XNCD5KHQ5";
            string secret = "P8OEvJHPdKoJuLCkEnLkaOUeTvLl";

            var accessData = new AccessData
            {
                Folder = folderPath,
                Address = bucketPath,
                AccessKey =key,
                PrivateKey = secret
            };
            _sut = new ForeCastDownloader(accessData);
        }
    }
}
