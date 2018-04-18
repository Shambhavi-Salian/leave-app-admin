using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leave_appz.UnitTest
{
    [TestClass]
    public class Leave_appzPageUnitTest
    {
        [TestMethod]
        public void ValidateLoginCredentialsWhenTrue()
        {
            //var validate = new JsonModelClass.UserDataModel();
            //Assert.IsTrue(validate.ApiResult("722"), "");
            var model = new JsonModelClass.UserDataModel();
            model.email_id = "seema";
            model.user_password = "123";
            Assert.IsTrue(model.CheckInformation(), "Username and Password text fields are not empty");
        }

        [TestMethod]
        public void ValidateLoginCredentialsWhenFalse()
        {
            //var validate = new JsonModelClass.UserDataModel();
            //Assert.IsTrue(validate.ApiResult("722"), "");
            var model = new JsonModelClass.UserDataModel();
            model.email_id = "";
            model.user_password = "";
            Assert.IsFalse(model.CheckInformation(), "Username and Password text fields are empty");
        }

       // [TestMethod]
       /// public void ValidateNetworkConnection()
       // {
        //    var navigation = new NetworkModel.NetworkManager();
        //    Assert.IsTrue(navigation.IsNetworkAvailable());
            //Assert.AreNotEqual(navigation.menuList.Count, 5);
            //app.Tap(x => x.Marked("Your Tab Title 1"));
            //app.Tap(x => x.Marked("Your Tab Title 2"));
            //app.Tap(x => x.Marked("Your Tab Title 3"));
       // }

    }
}
