using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leave_appz.Views
{
    public class Validator
    {

        public  bool ApiResult(string str)
        {
            

            if (str.Trim().Equals("722"))
            {

                return false;
            }
            else if (str.Trim().Equals("725"))
            {
                return false;
            }
            else if (str.Trim().Equals("721"))
            {
                return false;
            }
            
            else
            {
                return true;
            }

        }
        public bool LeavePersmissionResult(string str)
        {


            if (str.Trim().Equals("723"))
            {

                return true;
            }
          
            else
            {
                return false;
            }

        }

        public bool checkActionPerformed(string text)
        {
            if (text.Trim().Equals("Grant"))
            {

                return true;
            }else
            {
                return false;
            }
        }

        public bool dateSelectedTrue(string text)
        {
            if (text.Trim().Equals("2018-04-19"))
            {

                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
