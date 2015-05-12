using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    public class NewsController
    {
        public void setNews(News news) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.newsInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(news);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }

        public List<News> getNewsOf(int id) 
        {
            string url = Data.getDataClass().url + InterfaceUrl.newsGetOf_ + id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
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
        public List<News> getEndSevenNews()
        {
            string url = Data.getDataClass().url + InterfaceUrl.newsEndSeven;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
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
    }
}
