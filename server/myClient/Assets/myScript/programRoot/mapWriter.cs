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
    List<Point> delList;

    static GameObject selectedObj;

	void Start () {
        DataReader.Clear();
        objList = new List<GameObject>();
        delList = new List<Point>();
        EventMapBuild += CreateField;
        EventSaveMap += saveMap;
        EventAddPointMap += AddPointMap;
        EventSelectedPoint += SelectedPoint;
        EventOkOrCancelPointMap += OkOrCancelPoint;
        EventUpOrDownSizePointMap += UpOrDownSizePoint;
        EventActivJoystick += ActivJoystick;
        EventActivField += ActivField;
	}

    public GameObject joystick;
    public GameObject PointYoystick;
    

    public static bool isSelectedObj() { if (selectedObj == null) return false; else return true; }

    public static GameObject GetSelectedObj() { return selectedObj; }

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

    public delegate void activJoystickDelegate(bool val);
    public static event activJoystickDelegate EventActivJoystick;
    public static void CallActivJoystickChanged(bool val)
    {
        var handler = EventActivJoystick;
        if (EventActivJoystick != null) // если есть подписчики
        {
            EventActivJoystick(val);
        }
    }

    public delegate void activFieldDelegate();
    public static event activFieldDelegate EventActivField;
    public static void CallActivFieldChanged()
    {
        var handler = EventActivField;
        if (EventActivField != null) // если есть подписчики
        {
            EventActivField();
        }
    }

    void ActivField()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void UpOrDownSizePoint(bool isUp, bool isHorizontal) 
    {
        if (selectedObj == null) return;
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

    void ActivJoystick(bool val) {
        PointYoystick.SetActive(val);
    }

    void OkOrCancelPoint(bool isOk)
    {
        if (selectedObj == null) return;
        if (isOk) 
        {
        } 
        else 
        {
            pointObj script = selectedObj.GetComponent<pointObj>();
            delList.Add(script.GetPoint());
            objList.Remove(selectedObj);
            Destroy(selectedObj);
        }
    }

    void AddPointMap() 
    {
        GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
        point.AddComponent<pointObj>();
        pointObj script = point.GetComponent<pointObj>();
        script.SetPoint(new Point());
        objList.Add(point);

        point.transform.parent = this.gameObject.transform;
        point.transform.localScale = new Vector3((float)0.02, (float)0.02, (float)2);
        point.transform.localPosition = Vector3.zero;
        SelectedPoint(point);
    }

    void SelectedPoint(GameObject obj) 
    {
        selectedObj = obj;
        Joy2.point = selectedObj;
        ActivJoystick(true);
    }


    void CreateField(string patch, Maps map)
    {
        var tex = new Texture2D(2, 2);

        byte[] pngBytes;
        if(patch==null){
            DestroyThisData();
            pngBytes = getMap(map.id);
            DataReader.GetDataReader().patch = null;
            DataReader.GetDataReader().selectedMap = map;
        }
        else
        {
            pngBytes = File.ReadAllBytes(patch);
            DataReader.GetDataReader().patch = patch;
        }
        if (pngBytes == null) return;
        tex.LoadImage(pngBytes);
        GetComponent<Renderer>().material.mainTexture = tex;
        gameObject.transform.localScale = new Vector3(tex.width, tex.height, 1);

        Joystick joy = joystick.GetComponent<Joystick>();
        joy.Camera.transform.position = new Vector3(0, 0, -tex.height + (tex.height / 7));
        var maps =DataReader.GetDataReader().selectedMap;
        if (map != null) 
        {
            PointController pc = new PointController();
            var list = pc.getPoints(map.id);
            foreach (var pointObj in list)
            {
                GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
                point.AddComponent<pointObj>();
                pointObj script = point.GetComponent<pointObj>();
                script.SetPoint(pointObj);
                objList.Add(point);

                point.transform.parent = this.gameObject.transform;
                point.transform.localScale = new Vector3(pointObj.size_w, pointObj.size_h, (float)2);
                point.transform.localPosition = new Vector3(pointObj.x, pointObj.y, (float)0);
            }
        }

    }

    private void DestroyThisData() {
        foreach (GameObject go in objList) {
            Destroy(go);
        }
        objList.Clear();
        delList.Clear();
    }

    private void saveMap() 
    {
        if (DataReader.GetDataReader().selectedMap == null) return;
        int mapId = DataReader.GetDataReader().selectedMap.id;
        if (DataReader.GetDataReader().patch != null) 
        {
            byte[] pngBytes = File.ReadAllBytes(DataReader.GetDataReader().patch);
            sendMap(pngBytes, mapId);
        }
        List<Point> listPointUpd = new List<Point>();
        List<Point> listPointSet = new List<Point>();
        foreach (GameObject obj in objList) { 
            var p = obj.GetComponent<pointObj>();
            var point = p.GetPoint();
            point.id_map = mapId;
            point.size_h = obj.transform.localScale.y;
            point.size_w = obj.transform.localScale.x;
            point.x = obj.transform.localPosition.x;
            point.y = obj.transform.localPosition.y;
            if (point.id == 0) { listPointSet.Add(point); } else { listPointUpd.Add(point); }
        }
        PointController pc = new PointController();
        pc.delPoints(delList);
        pc.setPoints(listPointSet);
        pc.updPoint(listPointUpd);
        CreateField(null, DataReader.GetDataReader().selectedMap);
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
