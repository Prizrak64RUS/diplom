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
        public List<Point> getPoints(int idMap) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointFromMap_+idMap;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
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
