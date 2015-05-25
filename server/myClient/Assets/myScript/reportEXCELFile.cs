using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml;

namespace Assets.myScript
{
    class reportEXCELFile
    {
#if UNITY_STANDALONE_WIN
        public static string patch = Directory.GetCurrentDirectory() + "\\sopgReport\\";
#endif
#if UNITY_ANDROID
        public static string patch = "/sdcard/sopgReport/";
#endif

        public static bool fileCreate(string type, Event ev)
        {
            Directory.CreateDirectory(patch);
            var f = patch + ev.name + "_" + type + ".html";
            if (File.Exists(f)) { File.Delete(f); }
            ////создать пустой файл
            //File.Create(f);

            switch(type)
            {
                case "POINT":
                    {
                        return reportLog(f,ev);
                        break;
                    }
                case "CHAT":
                    {
                        return reportMessage(f,ev);
                        break;
                    }
                case "NEWS":
                    {
                        return reportNews(f,ev);
                        break;
                    }
            }
            return false;
        }
        public static bool reportNews(string f, Event ev) 
        {
            FileStream file = new FileStream(f,                                        
                                    FileMode.OpenOrCreate, 
                                       FileAccess.ReadWrite, 
                                       FileShare.None);
            TextWriter fnew = new StreamWriter(file, Encoding.UTF8);
            fnew.WriteLine("Событие \"" + ev.name + "\"");
            fnew.WriteLine("<table border=1>");
            fnew.WriteLine("<thead>");
            fnew.WriteLine("<th>Дата</th>");
            fnew.WriteLine("<th>Новость</th>");
            fnew.WriteLine("</thead>");
            fnew.WriteLine("<tbody>");
            //file.Write("");
            LogController lc = new LogController();
            int[] val = new int[2];
            val[0] = ev.id;
            val[1] = 0;
            while (true)
            {
                List<News> list = null;
                while (list == null)
                {
                    list = lc.getTreeLogsNews(val);
                }
                if (list.Count == 0)
                {

                    fnew.WriteLine("</tbody>");
                    fnew.WriteLine("</table>");
                    break;
                }

                foreach (News n in list)
                {
                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td>" + n.date_write + "</td>");
                    fnew.WriteLine("<td>" + n.description + "</td>");
                    fnew.WriteLine("</tr>");
                    val[1] = n.id;
                }
            }
            fnew.Flush();
            fnew.Close();
            return true;
        }

        public static bool reportLog(string f, Event ev)
        {
            FileStream file = new FileStream(f,
                                    FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.None);
            TextWriter fnew = new StreamWriter(file, Encoding.UTF8);
            fnew.WriteLine("Событие \"" + ev.name + "\"");
            fnew.WriteLine("<table border=1>");
            fnew.WriteLine("<thead>");
            fnew.WriteLine("<th>Дата</th>");
            fnew.WriteLine("<th>Пользователь</th>");
            fnew.WriteLine("<th>Тип лога</th>");
            fnew.WriteLine("<th>Информация</th>");
            fnew.WriteLine("</thead>");
            fnew.WriteLine("<tbody>");
            //file.Write("");
            LogController lc = new LogController();
            int[] val = new int[2];
            val[0] = ev.id;
            val[1] = 0;
            while (true)
            {
                List<Log> list = null;
                while (list == null)
                {
                    list = lc.getTreeLogsPoint(val);
                }
                if (list.Count == 0)
                {

                    fnew.WriteLine("</tbody>");
                    fnew.WriteLine("</table>");
                    break;
                }

                foreach (Log n in list)
                {
                    User valueUser = null;
                    getMap().TryGetValue(n.id_user, out valueUser);

                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td>" + n.date + "</td>");
                    fnew.WriteLine("<td>" + valueUser.name + "</td>");
                    fnew.WriteLine("<td>" + n.log_type + "</td>");
                    fnew.WriteLine("<td>" + n.description + "</td>");
                    fnew.WriteLine("</tr>");
                    val[1] = n.id;
                }
            }
            fnew.Flush();
            fnew.Close();
            return true;
        }

        static Dictionary<int, User> mapUsr;
        public static Dictionary<int, User> getMap() 
        {
            if(mapUsr==null)
            {
            while (Data.getDataClass().getUsers() == null) { }
            var listUsr = Data.getDataClass().getUsers();
            mapUsr = new Dictionary<int, User>();
            foreach (var usr in listUsr) 
            {
                mapUsr.Add(usr.id, usr);
            }
            }
            return mapUsr;
        }

        public static bool reportMessage(string f, Event ev)
        {
            FileStream file = new FileStream(f,
                                    FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.None);
            TextWriter fnew = new StreamWriter(file, Encoding.UTF8);
            fnew.WriteLine("Событие \"" + ev.name + "\"");
            fnew.WriteLine("<table border=1>");
            fnew.WriteLine("<thead>");
            fnew.WriteLine("<th>Дата</th>");
            fnew.WriteLine("<th>От кого</th>");
            fnew.WriteLine("<th>Кому</th>");
            fnew.WriteLine("<th>Сообщение</th>");
            fnew.WriteLine("</thead>");
            fnew.WriteLine("<tbody>");
            //file.Write("");
            LogController lc = new LogController();
            int[] val = new int[2];
            val[0] = ev.id;
            val[1] = 0;
            var mapUsr = getMap();
            while (true)
            {
                List<Message> list = null;
                while (list == null)
                {
                    list = lc.getTreeLogsChat(val);
                }
                if (list.Count == 0)
                {

                    fnew.WriteLine("</tbody>");
                    fnew.WriteLine("</table>");
                    break;
                }

                foreach (Message n in list)
                {
                    User valueUser = null;
                    mapUsr.TryGetValue(n.idUser, out valueUser);
                    string userTo=null;

                    if (n.idUserTo == 0)
                    {
                        userTo = "Всем";
                    }
                    else
                    {
                        User userToValue = null;
                        mapUsr.TryGetValue(n.idUserTo, out userToValue);
                        userTo = userToValue.name;
                    }
                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td>" + n.date + "</td>");
                    fnew.WriteLine("<td>" + valueUser.name + "</td>");
                    fnew.WriteLine("<td>" + userTo + "</td>");
                    fnew.WriteLine("<td>" + n.message + "</td>");
                    fnew.WriteLine("</tr>");
                    val[1] = n.id;
                }
            }
            fnew.Flush();
            fnew.Close();
            return true;
        }
    }
}
