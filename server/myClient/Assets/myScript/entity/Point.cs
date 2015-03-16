using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    class Point
    {
        public String name { get; set; }
        public String type { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float size_w { get; set; }
        public float size_h { get; set; }
        public String description { get; set; }
        public int id_map { get; set; }
        public bool isBusy { get; set; }
        public int id_user_Busy { get; set; }
        public int id { get; set; }

        public Point() { }

        public Point(String name, String type, float x, float y, float size_w, float size_h, String description, int id_map, bool isBusy, int id_user_Busy, int id)
        {
            this.name = name;
            this.type = type;
            this.description = description;
            this.x = x;
            this.id_map = id_map;
            this.id = id;
            this.y = y;
            this.isBusy = isBusy;
            this.id_user_Busy = id_user_Busy;
            this.size_w = size_w;
            this.size_h = size_h;

        }

    }
}
