using UnityEngine;
using System.Collections;
using RestSharp;
using Assets.myScript.entity;
using Newtonsoft.Json;
using Assets.myScript;
using System;
namespace Assets.myScript.interfaceUrl
{
    public class TestController
    {
        public static bool testConnect()
        {
            string url = Data.getDataClass().url + InterfaceUrl.test;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 2000;
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