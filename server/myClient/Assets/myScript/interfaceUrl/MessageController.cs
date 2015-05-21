using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    public class MessageController
    {
        public void setChatMessage(Message ms)
        {
            string url = Data.getDataClass().url + InterfaceUrl.chatInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(ms);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public List<Message> getChatOf(Int32[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.chatGetOf;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Message>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Message> getEndSevenMessage(Int32[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.chatEndSevenMessage;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Message>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
    }
}
