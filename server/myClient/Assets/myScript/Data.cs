using Assets.myScript.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript
{
    class Data
    {
        static Data data;
        public static Data getDataClass(){
            if (data == null) {
                data = new Data();
            }
            return data;
        }
        public List<Maps> mapsList { get; set; }
        public Event ev { get; set; }
        public User user{ get; set; }
        
    }
}
