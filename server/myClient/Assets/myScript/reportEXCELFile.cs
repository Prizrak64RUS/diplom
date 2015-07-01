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

        public static string fileCreate(string type, Event ev)
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
                        reportLog(f,ev);
                        break;
                    }
                case "CHAT":
                    {
                        reportMessage(f,ev);
                        break;
                    }
                case "NEWS":
                    {
                        reportNews(f,ev);
                        break;
                    }
                case "GROUP":
                    {
                        reportGroup(f, ev);
                        break;
                    }
            }
            return f;
        }
        public static void reportNews(string f, Event ev) 
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
                fnew.Flush();
            }
            
            fnew.Close();
        }

        public static void reportGroup(string f, Event ev)
        {
            FileStream file = new FileStream(f,
                                    FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.None);
            TextWriter fnew = new StreamWriter(file, Encoding.UTF8);

            //file.Write("");
            LogController lc = new LogController();
            int[] val = new int[2];
            val[0] = ev.id;
            val[1] = 0;
            List<Group> list=null;
            //while (list == null)
            //{
                list = lc.getTreeLogsGroup(val);
            //}

                fnew.WriteLine("Событие \"" + ev.name + "\"<br /><br />");
            fnew.WriteLine("<table border=1>");
            fnew.WriteLine("<thead>");
            fnew.WriteLine("<th>Город</th>");
            fnew.WriteLine("<th>Кол-во групп</th>");
            fnew.WriteLine("<th>Кол-во детей</th>");
            fnew.WriteLine("<th>Общее кол-во людей</th>");
            fnew.WriteLine("</thead>");
            fnew.WriteLine("<tbody>");
            fnew.Flush();
            string thisLoc = null;
            var arr = list.ToArray();
            int kg = 0;
            int kc = 0;
            int ka = 0;

            int kog = 0;
            int koc = 0;
            int koa = 0;
            Group notG = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].groupExist == 0)
                {
                    notG = arr[i];
                    if (i == arr.Length - 1) 
                    {
                        fnew.WriteLine("<tr>");
                        fnew.WriteLine("<td><b>Итого:</b></td>");
                        fnew.WriteLine("<td>" + kog + "</td>");
                        fnew.WriteLine("<td>" + koc + "</td>");
                        fnew.WriteLine("<td>" + koa + "</td>");
                        fnew.WriteLine("</tr>");
                        fnew.WriteLine("</tbody>");
                        fnew.WriteLine("</table><br /><br />");
                    }
                    continue;
                }
                if (thisLoc == null)
                    thisLoc = arr[i].location;
                if (!thisLoc.Equals(arr[i].location))
                {
                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td>" + thisLoc + "</td>");
                    fnew.WriteLine("<td>" + kg + "</td>");
                    fnew.WriteLine("<td>" + kc + "</td>");
                    fnew.WriteLine("<td>" + ka + "</td>");
                    fnew.WriteLine("</tr>");
                    kog += kg;
                    koc += kc;
                    koa += ka;
                    kg = 0;
                    kc = 0;
                    ka = 0;
                    thisLoc = arr[i].location;
                }
                kg++;
                kc += arr[i].number_child;
                ka += arr[i].numberOverall;
                if (i == arr.Length - 1)
                {
                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td>" + thisLoc + "</td>");
                    fnew.WriteLine("<td>" + kg + "</td>");
                    fnew.WriteLine("<td>" + kc + "</td>");
                    fnew.WriteLine("<td>" + ka + "</td>");
                    fnew.WriteLine("</tr>");
                    kog += kg;
                    koc += kc;
                    koa += ka;
                    fnew.WriteLine("<tr>");
                    fnew.WriteLine("<td><b>Итого:</b></td>");
                    fnew.WriteLine("<td>" + kog + "</td>");
                    fnew.WriteLine("<td>" + koc + "</td>");
                    fnew.WriteLine("<td>" + koa + "</td>");
                    fnew.WriteLine("</tr>");
                    fnew.WriteLine("</tbody>");
                    fnew.WriteLine("</table><br /><br />");
                    fnew.Flush();
                }
            }

            if(notG!=null){
                fnew.WriteLine("<table border=1>");
                fnew.WriteLine("<thead>");
                fnew.WriteLine("<th>Кол-во гостевых вхождений</th>");
                fnew.WriteLine("</thead>");
                fnew.WriteLine("<tbody>");
                fnew.WriteLine("<tr>");
                fnew.WriteLine("<td>" + notG.number_child + "</td>");
                fnew.WriteLine("</tr>");
                fnew.WriteLine("</tbody>");
                fnew.WriteLine("</table><br /><br />");
                fnew.Flush();
            }

            fnew.WriteLine("<table border=1>");
            fnew.WriteLine("<thead>");
            fnew.WriteLine("<th>Времмя прихода</th>");
            fnew.WriteLine("<th>Времмя ухода</th>");
            fnew.WriteLine("<th>Город</th>");
            fnew.WriteLine("<th>Учебное заведение</th>");
            fnew.WriteLine("<th>Ответственный</th>");
            fnew.WriteLine("<th>Кол-во ответственных</th>");
            fnew.WriteLine("<th>Кол-во детей</th>");
            fnew.WriteLine("<th>Общее кол-во людей</th>");
            fnew.WriteLine("</thead>");
            fnew.WriteLine("<tbody>");
            fnew.Flush();

            foreach (var g in list) 
            {
                if (g.groupExist == 0)
                    continue;

                fnew.WriteLine("<tr>");
                fnew.WriteLine("<td>" + g.ds + "</td>");
                fnew.WriteLine("<td>" + g.de + "</td>");
                fnew.WriteLine("<td>" + g.location + "</td>");
                fnew.WriteLine("<td>" + g.school + "</td>");
                fnew.WriteLine("<td>" + g.responsible + "</td>");
                fnew.WriteLine("<td>" + g.numberResponsible + "</td>");
                fnew.WriteLine("<td>" + g.number_child + "</td>");
                fnew.WriteLine("<td>" + g.numberOverall + "</td>");
                fnew.WriteLine("</tr>");
                fnew.Flush();
            }
            fnew.WriteLine("</tbody>");
            fnew.WriteLine("</table><br /><br />");
            fnew.Close();
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
                fnew.Flush();
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
                fnew.Flush();
            }
           
            fnew.Close();
            return true;
        }
    }
}
