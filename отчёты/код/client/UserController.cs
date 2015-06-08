using UnityEngine;
using System.Collections;
using RestSharp;
using Assets.myScript.entity;
using Newtonsoft.Json;
using Assets.myScript;
using System;
using System.Collections.Generic;
namespace Assets.myScript.interfaceUrl
{
    public class UserController
    {
        public void setUsers(List<User> user)
        {
            string url = Data.getDataClass().url + InterfaceUrl.userInsert;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            client.Timeout = 5000;
            var response = client.Execute(request);
        }
        public void updateUsers(List<User> user)
        {
            string url = Data.getDataClass().url + InterfaceUrl.userUpdate;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            client.Timeout = 2000;
            var response = client.Execute(request);
        }
        public void deleteUsers(List<User> user)
        {
            string url = Data.getDataClass().url + InterfaceUrl.userDelete;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            client.Timeout = 2000;
            var response = client.Execute(request);
        }
        public User isAutch(User user)
        {
            string url = Data.getDataClass().url + InterfaceUrl.userAuth;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            client.Timeout = 2000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<User>(content);
                return b;
            }
            catch (Exception e) { return user; }
        }
        public List<User> getUsers()
        {
            string url = Data.getDataClass().url + InterfaceUrl.userAll;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<User>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
        public List<User> getUsers(int idEvent)
        {
            string url = Data.getDataClass().url + InterfaceUrl.usersFromEvent_ + idEvent;
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Timeout = 5000;
            var response = client.Execute(request);
            var content = response.Content;
            try
            {
                var b = JsonConvert.DeserializeObject<List<User>>(content);
                return b;
            }
            catch (Exception e) { return null; }
        }
    }
}