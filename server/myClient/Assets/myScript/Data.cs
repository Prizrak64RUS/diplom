using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;
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
            user = new User("Управляющий Антон", "HEAD", "NONE", "NONE", 2006, 2, "NONE");
            //user = new User("Игорь Сергеев", "GUIDES", "NONE", "NONE", 2017, 12, "NONE");
            //user = new User("Сергей Петров", "PORTER", "NONE", "NONE", 2018, 14, "NONE");
            //user = new User("testUsr", "WATCHING", "NONE", "NONE", 0, "NONE");
        }

        public List<User> getUsers() 
        {
            if (userList == null) { UserController uc = new UserController(); userList = uc.getUsers(); }
            return userList;
        }

        public Event getEventThis()
        {
            if (eventThis == null) { EventController uc = new EventController(); eventThis = uc.getEventActiv(); }
            return eventThis;
        }

        public List<Maps> getMaps()
        {
            if (mapsList == null) { MapsController uc = new MapsController(); mapsList = uc.getMapsFromActivEvent(); }
            return mapsList;
        }

        public Busy getBusy()
        {
            if (busy == null) { BusyController uc = new BusyController(); busy = uc.isBusy(new Busy(user.id, getEventThis().id)); }
            return busy;
        }


        public bool isRead { get; set; }
        public bool isBusy { get; set; }
        Busy busy { get; set; }

        public string url { get; set; }
        public User user { get; set; }
        public List<Point> selectedMapPoint { get; set; }
        public Maps selectedMap { get; set; }

        List<Maps> mapsList { get; set; }
        Event eventThis { get; set; }
        List<User> userList { get; set; }
        
    }
//}
