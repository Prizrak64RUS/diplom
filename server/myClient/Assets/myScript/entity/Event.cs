using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Event
    {
        public string name { get; set; }
        public int isActiv { get; set; }
        public int isDelete { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public int id { get; set; }
        //private List<Maps> maps { get; set; }

        public Event() { }

        public Event(string name, int isActiv, string description, string date, int id)//, List<Maps> maps)
        {
            this.name = name;
            this.isActiv = isActiv;
            this.description = description;
            this.date = date;
            this.id = id;
        }
        public Event(string name, int isActiv, string description, string date)//, List<Maps> maps)
        {
            this.name = name;
            this.isActiv = isActiv;
            this.description = description;
            this.date = date;
            this.isDelete = 0;
        }

        public Event(int id)//, List<Maps> maps)
        {
            this.id = id;
        }
    }
}
