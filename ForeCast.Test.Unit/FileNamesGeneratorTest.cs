using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.Test.Unit
{

    [TestClass]
    public class FileNamesGeneratorTest
    {
        FileNamesGenerator _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new FileNamesGenerator();
        }

        [TestMethod]
        public void GetFileNamesTest()
        {
            DateTime date = DateTime.Parse("17-August-2021 11:00");
            var names = _sut.CreateFileNames(date);
            Assert.AreEqual(names.Bucket, "gfs.20210817/00/atmos/gfs.t00z.pgrb2.0p25.f011", "Bad bucket name");

        }

        [TestMethod]
        public void GetFileNamesOffsetTest()
        {
            DateTime date = DateTime.Today.AddHours(50);
            var names = _sut.CreateFileNames(date);
            Assert.IsTrue(names.Bucket.EndsWith("050"),"Bad offset bucket name");
            Assert.IsTrue(names.File.EndsWith("50"), "Bad offset bucket name");

        }
    }
}
