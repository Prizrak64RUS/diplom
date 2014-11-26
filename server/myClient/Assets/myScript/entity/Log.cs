using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    class Log
    {
        public String description { get; set; }
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_log_type { get; set; }
        public int id_events { get; set; }
        public int id_point { get; set; }
        public String date { get; set; }

        // private List<Maps> maps;

        public Log(String description, int id, int id_user, int id_log_type, int id_events, int id_point, String date)
        {
            this.description = description;
            this.id = id;
            this.id_user = id_user;
            this.id_log_type = id_log_type;
            this.id_events = id_events;
            this.id_point = id_point;
            this.date = date;

        }
    }
}
