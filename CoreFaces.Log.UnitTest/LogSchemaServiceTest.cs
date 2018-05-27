using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.UnitTest
{
    [TestClass]
    public class LogSchemaServiceTest : BaseTest
    {
        [TestMethod]
        public void DropTables()
        {
            _logSchemaService.DropTables();
        }

        [TestMethod]
        public void EnsureCreated()
        {
            _logSchemaService.EnsureCreated();
        }
    }
}
