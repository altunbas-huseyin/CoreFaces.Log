using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.UnitTest
{
    [TestClass]
    public class LogServiceTest : BaseTest
    {
        [TestMethod]
        public void LogSave()
        {
            Models.Domain.Log log = new Models.Domain.Log { Name = "test", LogCategoryId = Guid.NewGuid() };
            _logService.Save(log);

            _logService.Delete(log.Id);

        }
    }
}
