using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leave_appz.ViewModels
{

    public class EmployeeVM
    {
        public string email_id { get; set; }
        //public EmployeeViewModel. User { get; set; }
        public ObservableCollection<EmployeeViewModel> EmployeeList { get; set; }

        public EmployeeVM()
        {
            EmployeeList = new ObservableCollection<EmployeeViewModel>();
        }

    }
}
