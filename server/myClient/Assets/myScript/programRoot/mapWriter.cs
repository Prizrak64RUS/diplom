using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using System.IO;
using UnityStandardAssets.CrossPlatformInput;
using Assets.myScript.interfaceUrl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class mapWriter : MonoBehaviour {

    List<GameObject> objList;
    List<pointObj> pointList;


    GameObject selectedObj;

	// Use this for initialization
	void Start () {
        dataReader = new DataReader();
        pointList = new List<pointObj>();
        objList = new List<GameObject>();

        EventMapBuild += CreateField;
        EventSaveMap += saveMap;
        EventAddPointMap += AddPointMap;
        EventSelectedPoint += SelectedPoint;
        EventOkOrCancelPointMap += OkOrCancelPoint;
        EventUpOrDownSizePointMap += UpOrDownSizePoint;

	}

    public GameObject joystick;
    DataReader dataReader;

    public delegate void mapBuildDelegate(string patch, Maps map);
    public static event mapBuildDelegate EventMapBuild;
    public static void CallMapBuildChanged(string patch, Maps map)
    {
        var handler = EventMapBuild;
        if (EventMapBuild != null) // если есть подписчики
        {
            EventMapBuild(patch, map);
        }
    }

    public delegate void saveMapDelegate();
    public static event saveMapDelegate EventSaveMap;
    public static void CallSaveMapChanged()
    {
        var handler = EventSaveMap;
        if (EventSaveMap != null) // если есть подписчики
        {
            EventSaveMap();
        }
    }

    public delegate void addPointMapDelegate();
    public static event addPointMapDelegate EventAddPointMap;
    public static void CallAddPointMapChanged()
    {
        var handler = EventAddPointMap;
        if (EventAddPointMap != null) // если есть подписчики
        {
            EventAddPointMap();
        }
    }

    public delegate void upOrDownSizePointMapDelegate(bool isUp, bool isHorizontal);
    public static event upOrDownSizePointMapDelegate EventUpOrDownSizePointMap;
    public static void CallUpOrDownSizePointMapChanged(bool isUp, bool isHorizontal)
    {
        var handler = EventUpOrDownSizePointMap;
        if (EventUpOrDownSizePointMap != null) // если есть подписчики
        {
            EventUpOrDownSizePointMap(isUp, isHorizontal);
        }
    }

    public delegate void okOrCancelPointMapDelegate(bool isOk);
    public static event okOrCancelPointMapDelegate EventOkOrCancelPointMap;
    public static void CallOkOrCancelPointMapChanged(bool isOk)
    {
        var handler = EventOkOrCancelPointMap;
        if (EventOkOrCancelPointMap != null) // если есть подписчики
        {
            EventOkOrCancelPointMap(isOk);
        }
    }

    public delegate void selectedPointDelegate(GameObject obj);
    public static event selectedPointDelegate EventSelectedPoint;
    public static void CallSelectedPointChanged(GameObject obj)
    {
        var handler = EventSelectedPoint;
        if (EventSelectedPoint != null) // если есть подписчики
        {
            EventSelectedPoint(obj);
        }
    }

    void UpOrDownSizePoint(bool isUp, bool isHorizontal) 
    {
        Debug.Log(2);
        if (selectedObj == null) return;
        Debug.Log(3);
        float x, y;
        x= selectedObj.transform.localScale.x;
        y= selectedObj.transform.localScale.y;
        if (isHorizontal)
        {
            if (isUp)
            {
                if (x > 0.5) return;
                x+=(float)0.02;
                selectedObj.transform.localScale = new Vector3(x, y,2);
            }
            else
            {
                if (x < 0.04) return;
                x -= (float)0.02;
                selectedObj.transform.localScale = new Vector3(x,y,2);
            }
        }
        else
        {
            if (isUp)
            {
                if (x > 0.5) return;
                y += (float)0.02;
                selectedObj.transform.localScale = new Vector3(x, y, 2);
            }
            else
            {
                if (y < 0.04) return;
                y -= (float)0.02;
                selectedObj.transform.localScale = new Vector3(x, y, 2);
            }
        }

    }

    void OkOrCancelPoint(bool isOk)
    {
        if (selectedObj == null) return;
        if (isOk) 
        { } 
        else 
        {
            pointObj script = selectedObj.GetComponent<pointObj>();
            pointList.Remove(script);
            objList.Remove(selectedObj);
            Destroy(selectedObj);
        }
    }

    void AddPointMap() 
    {
        GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
        pointObj script = point.GetComponent<pointObj>();
        objList.Add(point);
        pointList.Add(script);

        point.transform.parent = this.gameObject.transform;
        point.transform.localScale = new Vector3((float)0.02, (float)0.02, (float)2);
        point.transform.localPosition = Vector3.zero;
        SelectedPoint(point);
    }

    void SelectedPoint(GameObject obj) 
    {
        selectedObj = obj;
        Joy2.point = selectedObj;
    }

    //void UpOrDownSizePointMap(bool isUp)
    //{
    //    if(isUp)
    //    {

    //    } 
    //    else
    //    {

    //    }
    //}
    //void OkOrCancelMap(bool isOk)
    //{
    //    selectedObj = null;
    //}

    void CreateField(string patch, Maps map)
    {
        var tex = new Texture2D(2, 2);

        byte[] pngBytes;
        if(patch==null){
            pngBytes = getMap(map.id);
            dataReader.patch = null;
            dataReader.selectedMap = map;
        }
        else
        {
            pngBytes = File.ReadAllBytes(patch);
            dataReader.patch = patch;
        }
        if (pngBytes == null) return;
        tex.LoadImage(pngBytes);
        GetComponent<Renderer>().material.mainTexture = tex;
        gameObject.transform.localScale = new Vector3(tex.width, tex.height, 1);

        Joystick joy = joystick.GetComponent<Joystick>();
        joy.Camera.transform.position = new Vector3(0, 0, -tex.height + (tex.height / 7));
        //foreach (var point in Data.getDataClass().mapsList[id_map].points)
        //{
        //    GameObject obj = (GameObject)Instantiate(Resources.Load(("objButtInMap")));
        //    obj.name = "point " + point.name;
        //    obj.transform.parent = field.transform;
        //    obj.transform.localPosition = new Vector3(point.x, point.y, 0);
        //    obj.transform.localScale = new Vector3(point.size_h, point.size_w, (float)1.2);
        //}
    }

    private void saveMap() 
    {
        if (dataReader.selectedMap == null) return;
        if (dataReader.patch != null) 
        {
            byte[] pngBytes = File.ReadAllBytes(dataReader.patch);
            sendMap(pngBytes, dataReader.selectedMap.id);
        }
    }

    private void sendMap(byte[] pngBytes, int id)
    {
        MapsController mc = new MapsController();
        mc.sendMapIn(pngBytes, id);
    }
    private byte[] getMap(int id) 
    {
        MapsController mc = new MapsController();
        return mc.sendMapOUT(id);
    }
}
