
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OilView.Models;

namespace OilView.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var path = @"c:\Temp\test.json";

            var testData = new FileData(DateTime.Now, "todoJob", "doneJob");
            var manager = new FileManager();
            await manager.WriteAsync(path, testData);
            var actual = await manager.ReadAsync(path);
            Assert.AreEqual(testData, actual);
        }
    }
}
