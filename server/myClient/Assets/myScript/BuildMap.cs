using UnityEngine;
using System.Collections;
using RestSharp;
using Assets.myScript.entity;
using Newtonsoft.Json;
using Assets.myScript;
using System.Collections.Generic;

public class BuildMap : MonoBehaviour {
	// Use this for initialization
    //void Start () {
    //    var client = new RestClient(Data.getDataClass().url+InterfaceUrl.getDataClass().allMap+1);
    //    var request = new RestRequest(Method.POST);
    //    var response = client.Execute(request);
    //    var content = response.Content;
    //    Debug.Log(content);
    //    var b= JsonConvert.DeserializeObject<List<Maps>>(content);
    //    Data.getDataClass().mapsList = b;
    //    client = new RestClient(Data.getDataClass().url + InterfaceUrl.getDataClass().allPoint + b[0].id);
    //    request = new RestRequest(Method.POST);
    //    response = client.Execute(request);
    //    content = response.Content;
    //    Debug.Log(content);
    //    var c = JsonConvert.DeserializeObject<List<Point>>(content);
    //    Data.getDataClass().mapsList[0].points = c;
    //    CreateField(0);
        
    //}

    void CreateField(int id_map)
    {
        //Тело поля
        GameObject field = this.gameObject;
        foreach (var point in Data.getDataClass().mapsList[id_map].points)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load(("objButtInMap")));
            obj.name = "point " + point.name;
            obj.transform.parent = field.transform;
            obj.transform.localPosition = new Vector3(point.x, point.y, 0);
            obj.transform.localScale = new Vector3(point.size_h, point.size_w, (float)1.2);
        }
    }
}
