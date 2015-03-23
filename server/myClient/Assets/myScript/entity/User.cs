using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class User
    {

        public String name { get; set; }
        public String role { get; set; }
        public String description { get; set; }
        public String login { get; set; }
        public int id { get; set; }
        public String password { get; set; }
        public int gradebook { get; set; }

        public User(String name, String role, String description, String login, int id, int gradebook)
        {
            this.name = name;
            this.role = role;
            this.description = description;
            this.login = login;
            this.id = id;
            this.gradebook = gradebook;
        }

        public User() { }

        public User(String login, String password)
        {
            this.login = login;
            this.password = password;
            this.role = "NONE";

        }
    }
}
