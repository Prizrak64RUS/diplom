using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class EventController
    {
        public void setEvent(List<Event> events)
        {
            string url = Data.getDataClass().url + InterfaceUrl.eventInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(events);
            client.Timeout = 5000;
            var response = client.Execute(request);
            
        }

        public Event getEventActiv()
        {
            string url = Data.getDataClass().url + InterfaceUrl.eventGetActiv;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 10000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<Event>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public List<Event> getEvents()
        {
            string url = Data.getDataClass().url + InterfaceUrl.eventAll;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 10000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Event>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public void updEvents(List<Event> events)
        {
            string url = Data.getDataClass().url + InterfaceUrl.eventUpd;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(events);
            client.Timeout = 10000;
            var response = client.Execute(request);
        }
    }
}
