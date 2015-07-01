using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class LogController
    {
        public List<Message> getTreeLogsChat(Int32[] val) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.logChat;
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


        public List<News> getTreeLogsNews(Int32[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.logNews;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<News>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<Log> getTreeLogsPoint(Int32[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.logPoint;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<Log>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }

        public List<Group> getTreeLogsGroup(Int32[] val)
        {
            string url = Data.getDataClass().url + InterfaceUrl.logGroup;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(val);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                test.Logs(content);
                var b = JsonConvert.DeserializeObject<List<Group>>(content);
                return b;
            }
            catch (Exception e) { test.Logs(e.StackTrace); return null; }
        }
    }
}
