using CoreFaces.Log.Models.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.UnitTest
{
    [TestClass]
    public class LogCategoryServiceTest : BaseTest
    {
        [TestMethod]
        public void LogCategorySave()
        {
            LogCategory logCategory = new LogCategory { Name="Order", Description="Order log category.", StatusId=2  };
            _logCategoryService.Save(logCategory);

            _logCategoryService.Delete(logCategory.Id);

        }
    }
}
