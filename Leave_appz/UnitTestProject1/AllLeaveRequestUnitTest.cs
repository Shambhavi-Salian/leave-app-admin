using System;
using Leave_appz.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leave_appz.UnitTest
{
    [TestClass]
    public class AllLeaveRequestUnitTest
    {
        [TestMethod]
        public void ApiResultTrue()
        {

            var validator = new Leave_appz.Views.Validator();
           // Assert.IsTrue(validator.ApiResult(""), "Placeholder Shuld not be empty");
            Assert.IsFalse(validator.ApiResult("722"), "No Data Retrieved From server");
            Assert.IsFalse(validator.ApiResult("725"), "Wrong id");
            Assert.IsFalse(validator.ApiResult("721"), "Database Connection Failed");
            Assert.IsTrue(validator.ApiResult(""), "Data Retreived from server");
            
        }

        [TestMethod]
        public void ApiResultFail()
        {

            var validator = new Leave_appz.Views.Validator();
           Assert.IsTrue(validator.ApiResult("722"), "Test case failed testcases");
          
        }

        [TestMethod]
        public void LeavePersmissionResultTrue()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsTrue(validator.LeavePersmissionResult("723"), "Leave grant/reject successfull");
            Assert.IsFalse(validator.LeavePersmissionResult(""), "Leave grant/reject failed");
        }

        [TestMethod]
        public void LeavePersmissionResultFailed()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsFalse(validator.LeavePersmissionResult("723"), "Leave grant/reject failed testcases");
        }


        [TestMethod]
        public void LeavePersmissionResultGrantTrue()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsTrue(validator.checkActionPerformed("Grant"), "Leave grant button clicked");
        }
        public void LeavePersmissionResultRejectTrue()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsFalse(validator.checkActionPerformed("Reject"), "Leave reject button clicked");
        }
        [TestMethod]
        public void LeavePersmissionResulGranttFail()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsFalse(validator.checkActionPerformed("Grant"), "Leave grant button click failed testcases");
        }
        public void LeavePersmissionResultRejectFail()
        {
            var validator = new Leave_appz.Views.Validator();
            Assert.IsTrue(validator.checkActionPerformed("Reject"), "Leave reject button click failed testcases");
        }
    }
}
