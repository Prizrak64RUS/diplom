using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Schedulepoint
    {
        public int id { get; set; }
        public int id_masterclass { get; set; }
        public int id_point { get; set; }
        public String date_start { get; set; }
        public String time_start { get; set; }
        public String time_end { get; set; }

    public Schedulepoint(int id, int id_masterclass, int id_point, String date_start, String time_start, String time_end) {
        this.id = id;
        this.id_masterclass = id_masterclass;
        this.date_start = date_start;
        this.id_point = id_point;
        this.time_start = time_start;
        this.time_end = time_end;
    }

    public Schedulepoint()
    {
        this.id = 0;
        this.id_masterclass = 0;
        this.date_start = "";
        this.id_point = 0;
        this.time_start = "";
        this.time_end = "";
    }

    public int hashCode(){
        return id;
    }

    public bool Equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        Schedulepoint other = (Schedulepoint) obj;
        if (id!=((Schedulepoint) obj).id)
            return false;
        return true;
    }
    }
}
