using UnityEngine;
using System.Collections;
using RestSharp;
using Assets.myScript.entity;
using Newtonsoft.Json;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var client = new RestClient("http://localhost:8080/user/");
        var request = new RestRequest(Method.POST);
        request.AddJsonBody(new User("admin", "admin"));
        var response = client.Execute(request);
        var content = response.Content;
        //Console.WriteLine("LOL "+content);
        var b = JsonConvert.DeserializeObject<User>(content); ;
        Debug.Log(content);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
