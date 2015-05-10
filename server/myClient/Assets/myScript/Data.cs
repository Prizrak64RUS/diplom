using Assets.myScript.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace Assets.myScript
//{
    class Data
    {
        static Data data;
        public static Data getDataClass(){
            if (data == null) {
                data = new Data();
            }
            return data;
        }
        private Data() { url = "http://localhost:8080"; }
        
        public string url { get; set; }
        public User user { get; set; }
        public List<Maps> mapsList { get; set; }
        public Maps selectedMap { get; set; }
        public List<Point> selectedMapPoint { get; set; }
        public Event ev { get; set; }
        
    }
//}
