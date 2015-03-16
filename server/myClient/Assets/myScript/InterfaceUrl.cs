using Assets.myScript.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript
{
    class InterfaceUrl
    {
        static InterfaceUrl obj;
        public static InterfaceUrl getDataClass(){
            if (obj == null)
            {
                obj = new InterfaceUrl();
            }
            return obj;
        }
        private InterfaceUrl() { }
        public string allMap = "/maps/allMap/";
        public string allPoint = "/maps/allPoint/";
        public string test = "/test/1";
        public string user = "/user/";
        
    }
}
