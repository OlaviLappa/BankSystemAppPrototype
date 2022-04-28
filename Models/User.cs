using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp
{
    class User
    {
        public User() { }

        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;

            Authorization authorization = new Authorization();
            authorization.SignIn(this);
        }

        private string Login { get; set; }
        private string Password { get; set; }

        public string GetLogin()
        {
            return Login;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
