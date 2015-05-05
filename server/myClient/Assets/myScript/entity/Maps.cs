using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Maps
    {
        public String name { get; set; }
        public int id_event { get; set; }
        public String description { get; set; }
        public int id { get; set; }
        //public List<Point> points { get; set; }

        public Maps() { }

        public Maps(String name, int id_event, String description, int id)
        {
            this.name = name;
            this.id_event = id_event;
            this.description = description;
            this.id = id;
        }

        //public Maps(String name, int id_event, String description, int id, List<Point> points)
        //{
        //    this.name = name;
        //    this.id_event = id_event;
        //    this.description = description;
        //    this.id = id;
        //    this.points = points;
        //}
    }
}
