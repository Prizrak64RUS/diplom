using Assets.myScript.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript
{
    class InterfaceUrl
    {
        //static InterfaceUrl obj;
        //public static InterfaceUrl getDataClass(){
        //    if (obj == null)
        //    {
        //        obj = new InterfaceUrl();
        //    }
        //    return obj;
        //}
        private InterfaceUrl() { }
        public static string test = "/test";

        public static string userInsert = "/user/insert";
        public static string userUpdate = "/user/update";
        public static string userDelete = "/user/delete";
        public static string userAll = "/user/allUser";
        public static string usersFromEvent_ = "/user/allUser/";
        public static string userAuth = "/user/auth";

        public static string mapFromEventAll = "/maps/allMap/in/";
        public static string mapFromId_ = "/maps/allMap/id/";
        public static string mapActivEventAll = "/maps/allMap/selected/";
        public static string mapAll = "/maps/allMap";
        public static string mapsInsert = "/maps/insert";
        public static string mapsDelete = "/maps/delete";
        public static string mapsUpdate = "/maps/update";
        public static string mapsSendOut_ = "/maps/sendOut/";
        public static string mapsSendIn_ = "/maps/sendIn/";
        public static string mapSize_ = "/maps/mapSize/";

        public static string eventGetActiv = "/event/getActiv";
        public static string eventInsert = "/event/insert";
        public static string eventAll = "/event/allEvent";
        public static string eventUpd = "/event/upd";

        public static string pointFromMap = "/point/allPoint/";
        public static string pointUpdate = "/point/update";
        public static string pointsInsert = "/point/inserts";
        public static string pointDelete = "/point/delete";

        public static string logInsert = "/log/insert";
        public static string logGetTreeLog_ = "/log/treeLogs/";
        public static string logGetTreeLogByType = "/log/treeLogs";

        public static string chatInsert = "/chat/insert";
        public static string chatGetOf = "/chat/getOf/";
        public static string chatEndSevenMessage = "/chat/endSevenMessage";

        public static string newsInsert = "/news/insert";
        public static string newsGetOf_ = "/news/getOf/";
        public static string newsEndSeven = "/news/endSeven";

        public static string busyInsert = "/busy/insert";
        public static string busyDel = "/busy/delete";
        public static string busyIs = "/busy/is";
    }
}
