using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class PointController
    {
        public List<Point> getPoints(string role, int idMap) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointFromMap;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            Object[] arr = { role, idMap };
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Point>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        //public List<Point> getPointsFromUserRole(string role, int idMap)
        //{
        //    var list = getPoints(idMap);
        //    if (list == null) return null;
        //    if (UserRole.HEAD.Equals(role) || UserRole.PORTER.Equals(role)) return list;
        //    List<Point> lp = new List<Point>();
        //    foreach(var el in list)
        //    {
        //        switch (role) 
        //        {
        //            case UserRole.GUIDES:
        //                {
        //                if (PointType.isTypeGUIDES(el.type))
        //                    lp.Add(el);
        //                break;
        //                }
        //            case UserRole.WATCHING:
        //                {
        //                if(PointType.isTypeStandart(el.type)) 
        //                    lp.Add(el);
        //                break;
        //                }
        //        }
        //    }
        //    return lp;
            
        //}

        public void updPoint(List<Point> points) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointUpdate;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(points);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public void setPoints(List<Point> points) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointsInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(points);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public void delPoints(List<Point> points) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointDelete;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(points);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
    }
}
