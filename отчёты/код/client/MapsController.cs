using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class MapsController
    {

        public long mapSize(int id){
            string url = Data.getDataClass().url + InterfaceUrl.mapSize_ + id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<long>(content);
                return b;
            }
            catch (Exception e) { return -1; }
        }

        public Maps getMap(int id)
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapFromId_+id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Maps>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Maps> getMaps(Event ev) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapFromEventAll;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(ev);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Maps>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Maps> getMaps()
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapAll;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Maps>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public List<Maps> getMapsFromActivEvent()
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapActivEventAll;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Maps>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public void setMap(List<Maps> map) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapsInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(map);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void sendMapIn(byte[] file, int id)
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapsSendIn_+id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(file);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public byte[] sendMapOUT(int id) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapsSendOut_+id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 7000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                Int32[] bi = JsonConvert.DeserializeObject<Int32[]>(content);
                byte[] b = new byte[bi.Length];
                for (int i = 0; i < bi.Length; i++)
                {
                    b[i] = (byte)bi[i];
                }
                    return b;
            }
            catch (Exception e) { return null; }
        }
        public void delMap(List<Maps> map) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapsDelete;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(map);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public void updMap(List<Maps> map)
        {
            string url = Data.getDataClass().url + InterfaceUrl.mapsUpdate;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(map);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
    }
}
