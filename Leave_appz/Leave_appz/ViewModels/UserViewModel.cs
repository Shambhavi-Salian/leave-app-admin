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
        public class UserViewModels

        {

      

        private ObservableCollection<User> users;
            public ObservableCollection<User> Users
            {
                get { return users; }
                set
                {
                    users = value;
                }
            }

            public UserViewModels(List<User> res)
            {

                Users = new ObservableCollection<User>();

                //MyData1 _context = new MyData1();

                foreach (var users in res)
                {
                    Users.Add(users);
                }


            }

        }
    }