using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    class Log
    {
        public string description { get; set; }
        public int id { get; set; }
        public int id_user { get; set; }
        public string log_type { get; set; }
        public int id_events { get; set; }
        public int id_point { get; set; }
        public int id_map { get; set; }
        public string date { get; set; }

        // private List<Maps> maps;

        public Log() { }

        public Log(String description, int id, int id_user, string log_type, int id_events, int id_point, String date, int id_map)
        {
            this.description = description;
            this.id = id;
            this.id_user = id_user;
            this.log_type = log_type;
            this.id_events = id_events;
            this.id_point = id_point;
            this.date = date;
            this.id_map = id_map;

        }
    }
}
