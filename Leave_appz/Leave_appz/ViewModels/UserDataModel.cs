using Leave_appz.Models;
using Leave_appz.MyDataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Leave_appz.ViewModels
{
    public class UserDataModel
    {
        public string email_id { get; set; }
        public string user_password { get; set; }

        public UserDataModel()
        {

        }

        public UserDataModel(string username, string password)
        {
            this.email_id = username;
            this.user_password = password;
        }

        public bool CheckInformation()
        {
            if (!this.email_id.Equals("") && !this.user_password.Equals(""))
                return true;
            else
                return false;
        }
        public class UserLeaveCount
        {
            public string leave_count { get; set; }
        }
    }

   
}