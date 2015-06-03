using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class SchedulepointController
    {
        public List<Schedulepoint> getSchedulepoint(int val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointGetFrom;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Schedulepoint>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Schedulepoint> getSchedulepoint()
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointGet;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Schedulepoint>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public void updSchedulepoint(List<Schedulepoint> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointUpd;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void setSchedulepoint(List<Schedulepoint> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointIns;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void delSchedulepoint(List<Schedulepoint> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointDel;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public Schedulepoint getSP(Int32 id)
        {
            string url = Data.getDataClass().url + InterfaceUrl.schedulepointGetOne;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(id);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Schedulepoint>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
    }
}
