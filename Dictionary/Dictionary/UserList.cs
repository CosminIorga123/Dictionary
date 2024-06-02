using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class UserList
    {
        public ObservableCollection<User> Users { get; set; }
        public User currentUser { get; set; }
        public UserList()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
