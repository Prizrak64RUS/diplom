﻿using Assets.myScript.entity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.myScript.interfaceUrl
{
    class GroupController
    {

        public bool updGroup(Group g)
        {
            string url = Data.getDataClass().url + InterfaceUrl.groupUpdate;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(g);
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

        public bool setGroup(Group g)
        {
            string url = Data.getDataClass().url + InterfaceUrl.groupInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(g);
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