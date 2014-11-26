using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    class Event
    {
        public String name { get; set; }
        public bool isActiv { get; set; }
        public String description { get; set; }
        public String date { get; set; }
        public int id { get; set; }
        //private List<Maps> maps { get; set; }

        public Event(String name, bool isActiv, String description, String date, int id)//, List<Maps> maps)
        {
            this.name = name;
            this.isActiv = isActiv;
            this.description = description;
            this.date = date;
            this.id = id;
        }
    }
}
