using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leave_appz.UnitTest
{
    [TestClass]
    public class CurrentdayAbsent
    {

        [TestMethod]
        public void CurrentDayCheck()
        {

            var validator = new Leave_appz.Views.Validator();
            Assert.IsTrue(validator.dateSelectedTrue("2018-04-19"), "today's date selected");
            Assert.IsFalse(validator.dateSelectedTrue("2018-04-20"), "today's not date selected");

        }

        [TestMethod]
        public void ApiResultTrue()
        {

            var validator = new Leave_appz.Views.Validator();
            Assert.IsFalse(validator.ApiResult("722"), "No Data Retrieved From server");
            Assert.IsFalse(validator.ApiResult("725"), "Wrong id");
            Assert.IsFalse(validator.ApiResult("721"), "Database Connection Failed");
            Assert.IsTrue(validator.ApiResult(""), "Data Retreived from server");

        }

        [TestMethod]
        public void ApiResultFail()
        {

            var validator = new Leave_appz.Views.Validator();
            Assert.IsTrue(validator.ApiResult("722"), "Test case failed");

        }
    }
}
