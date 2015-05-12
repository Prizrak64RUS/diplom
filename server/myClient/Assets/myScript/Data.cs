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
        private Data() 
        { 
            isRead = false;
            url = "http://localhost:8080";
            user = new User("testUsr", "WATCHING", "NONE", "NONE", 0, "NONE");
        }


        public bool isRead { get; set; }
        public bool isBusy { get; set; } 


        public string url { get; set; }
        public User user { get; set; }
        public List<Maps> mapsList { get; set; }
        public Maps selectedMap { get; set; }
        public List<Point> selectedMapPoint { get; set; }
        public Event eventThis { get; set; }
        
    }
//}
