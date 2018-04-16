using System;
using System.Collections.Generic;
using System.Text;

namespace Leave_appz.Models
{
    public class User
    {

        public int auto_id { get; set; }
        public String email_id { get; set; }
        public String description { get; set; }

        //  public String type_of_leave { get; set; }
        //  public int _type_of_leave { get; set; }
        private string _Text;
        public string type_of_leave
        {
            get
            {

                return _Text;

            }
            set
            {
                if (value.Equals("0"))
                {
                    _Text = "Sick Leave";
                }
                else if (value.Equals("1"))
                {
                    //DEFAULT Value. 
                    _Text = "Casual Leave";
                }
                else if (value.Equals("2"))
                {
                    //DEFAULT Value. 
                    _Text = "Earned Leave";
                }
            }
        }

        // public String Email { get; set; }
        public String leave_date { get; set; }


    }

}