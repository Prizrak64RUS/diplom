using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assets.myScript.interfaceUrl
{
    class MasterclassController
    {
        public List<Masterclass> getMasterclass(Int32 val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassGetFrom;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Masterclass>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Masterclass> getMasterclass()
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassGet;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Masterclass>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public void updMasterclass(List<Masterclass> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassUpd;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void setMasterclass(List<Masterclass> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassIns;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void delMasterclass(List<Masterclass> arr)
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassDel;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(arr);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public Masterclass getMC(Int32 id)
        {
            string url = Data.getDataClass().url + InterfaceUrl.masterclassGetFrom;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(id);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Masterclass>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
    }
}
