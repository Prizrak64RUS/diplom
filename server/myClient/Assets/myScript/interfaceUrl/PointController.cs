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
        public List<Point> getPoints(Object[] arr) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointFromMap;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
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


        public bool busyPoint(Point point) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointBusy;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }

        public bool busyNotPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointNotBusy;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }
        public bool updateBusyPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointsBusyUpdate;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }
        public bool delBusyPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointBusyDelete;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }

        public bool setBusyPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointBusyInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }

        public Point getPoint(int id)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointGetPoint_+id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Point>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public Point setPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointSetPoint;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Point>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public bool delPoint(Point point)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointDelPoint;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(point);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }

        public bool updFree_space(Object[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.pointBusyInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<bool>(content);
                return b;
            }
            catch (Exception e) { return false; }
        }
    }
}
