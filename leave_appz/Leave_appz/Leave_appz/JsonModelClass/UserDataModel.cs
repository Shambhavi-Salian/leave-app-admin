namespace JsonModelClass
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

        public bool checkInformation()
        {
            if (!this.email_id.Equals("") && !this.user_password.Equals(""))
                return true;
            else
                return false;
        }

       
    }
}