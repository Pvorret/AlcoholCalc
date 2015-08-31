using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Login
{
    public class Login
    {
        private Person.Person P;
        private string _userName;
        private string _password;
        public Dictionary<string, string> _users;

        public Login()
        {

        }
        public Login(Person.Person p)
        {
            _users = new Dictionary<string, string>();
            this.P = p;
        }

        public string CreateUser(string userName, string password)
        {
            string response;
            if (Regex.IsMatch(userName, @"^[a-zA-Z0-9]+$") && Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                if(userName.Length >= 2 && password.Length >= 6 && password.Length <= 10)
                {
                    _users.Add(userName, password);
                    response = "User created";
                }
                else
                {
                    response = "You need input a better UserName or Password";
                } 
            }
            else
            {
                response = "You need input a better UserName or Password";
            }
            return response;

        }

        public bool LoginResponse(string userName, string password)//Find på et bedre navn
        {
            bool loginSuccess = false;

            foreach (KeyValuePair<string, string> s in _users)
            {
                if (s.Key == userName && s.Value == password)
                {
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
                }
            }

            return loginSuccess;
        }
    }
}
