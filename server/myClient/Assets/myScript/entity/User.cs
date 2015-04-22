using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class User
    {

        public string name { get; set; }
        public string role { get; set; }
        public string description { get; set; }
        public string login { get; set; }
        public int id { get; set; }
        public string password { get; set; }
        public int gradebook { get; set; }

        public User(string name, string role, string description, string login, int id, int gradebook, string password)
        {
            this.name = name;
            this.role = role;
            this.description = description;
            this.login = login;
            this.id = id;
            this.gradebook = gradebook;
            this.password = password;
        }

        public User(string name, string role, string description, string login, int gradebook, string password)
        {
            this.name = name;
            this.role = role;
            this.description = description;
            this.login = login;
            this.gradebook = gradebook;
            this.password = password;
        }

        public User() {
            this.name = "";
            this.role = "NONE";
            this.description = "";
            this.login = "";
            this.password = "";
            this.id = 0;
            this.gradebook = 0;
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.role = "NONE";

        }
    }
}
