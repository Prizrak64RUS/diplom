using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class BusyController
    {
        public void setBusy(Busy b) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.busyInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(b);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public Busy isBusy(Busy b) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.busyIs;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(b);
            client.Timeout = 10000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var obj = JsonConvert.DeserializeObject<Busy>(content);
                return obj;
            }
            catch (Exception e) { return null; }
        }
        public void delBusy(Busy b) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.busyInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(b);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
    }
}
