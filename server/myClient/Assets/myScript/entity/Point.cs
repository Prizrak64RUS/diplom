﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.entity
{
    public class Point
    {
        public string name { get; set; }
        public string type { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float size_w { get; set; }
        public float size_h { get; set; }
        public string description { get; set; }
        public int id_map { get; set; }
        public int busy { get; set; }
        public int id_user_Busy { get; set; }
        public int id { get; set; }
        public int all_space { get; set; }
        public int free_space { get; set; }

        public Point(string name, string type, float x, float y, float size_w, float size_h, string description, int id_map, int busy, int id_user_Busy, int id)
        {
            this.name = name;
            this.type = type;
            this.description = description;
            this.x = x;
            this.id_map = id_map;
            this.id = id;
            this.y = y;
            this.busy = busy;
            this.id_user_Busy = id_user_Busy;
            this.size_w = size_w;
            this.size_h = size_h;
            all_space = 0;
        }

        public Point(string name, string type, string description, int id, int id_user_Busy, int all_space)
        {
            this.all_space = all_space;
            this.name = name;
            this.type = type;
            this.description = description;
            this.id = id;
            this.id_user_Busy = id_user_Busy;
            this.x = 0;
            this.id_map = 0;
            this.y = 0;
            this.busy = 0;
            this.size_w = 0;
            this.size_h = 0;

        }

        public Point(int id, int id_user_Busy, int busy, string name, string type, string description)
        {
            this.name = name;
            this.type = type;
            this.description = description;
            this.id = id;
            this.id_user_Busy = id_user_Busy;
            this.x = 0;
            this.id_map = 0;
            this.y = 0;
            this.busy = busy;
            this.size_w = 0;
            this.size_h = 0;
            all_space = 0;

        }

        public Point()
        {
            this.name = "";
            this.type = "ACTIV";
            this.description = "";
            this.x = 0;
            this.id_map = 0;
            this.id = 0;
            this.y = 0;
            this.busy = 0;
            this.id_user_Busy = 0;
            this.size_w = 0;
            this.size_h = 0;
            all_space = 0;

        }

        public Point(string type)
        {
            this.name = "";
            this.type = type;
            this.description = "";
            this.x = 0;
            this.id_map = 0;
            this.id = 0;
            this.y = 0;
            this.busy = 0;
            this.id_user_Busy = 0;
            this.size_w = 0;
            this.size_h = 0;
            all_space = 0;

        }

        public bool Equals(Object obj) 
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            Point other = (Point)obj;
            if (id != other.id)
                return false;

            if (busy != other.busy)
                return false;
            if (id_user_Busy != other.id_user_Busy)
                return false;

            if (y != other.y)
                return false;
            if (x != other.x)
                return false;

            if (size_w != other.size_w)
                return false;
            if (size_h != other.size_h)
                return false;
            return true;
        }

    }
}
