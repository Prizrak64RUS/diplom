using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Masterclass
    {
        public int id { get; set; }
        public int id_event { get; set; }
        public string name { get; set; }
        public string decription{ get; set; }
        public string lecturer1{ get; set; }
        public string lecturer2{ get; set; }
        public string lecturer3{ get; set; }



    public Masterclass(int id, int id_event, String name, String decription, String lecturer1, String lecturer3, String lecturer2) {
        this.id = id;
        this.id_event = id_event;
        this.name = name;
        this.decription = decription;
        this.lecturer1 = lecturer1;
        this.lecturer3 = lecturer3;
        this.lecturer2 = lecturer2;
    }
    public Masterclass(int id_event)
    {
        this.id = 0;
        this.id_event = id_event;
        this.name = "";
        this.decription = "";
        this.lecturer1 = "";
        this.lecturer3 = "";
        this.lecturer2 = "";
    }

    public Masterclass()
    {
    }

    public int hashCode(){
        return id;
    }

    public bool equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        Masterclass other = (Masterclass) obj;
        if (id!=((Masterclass) obj).id)
            return false;
        return true;
    }
    }
}
