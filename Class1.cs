using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class UserList : List<User>
    {

    }
    public class User
    {
        private string password;
        private string login;

        public User()
        {
        }

        public User(string Login, string Password)
        {
            this.login = Login;
            this.password = Password;
        }

        public string Login { get; set; }
        public string Pass { get; set; }

    }
}
