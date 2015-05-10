using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityStandardAssets.CrossPlatformInput;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;

public class mapController : MonoBehaviour {


    List<GameObject> objList;

    static GameObject selectedObj;

    void Start()
    {
        DataReader.Clear();
        objList = new List<GameObject>();
        EventMapBuild += CreateField;
        EventActivField += ActivField;
    }

    public GameObject joystick;

    public delegate void mapBuildDelegate(Maps map);
    public static event mapBuildDelegate EventMapBuild;
    public static void CallMapBuildChanged(Maps map)
    {
        var handler = EventMapBuild;
        if (EventMapBuild != null) // если есть подписчики
        {
            EventMapBuild(map);
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

    void CreateField(Maps map)
    {
        var tex = new Texture2D(2, 2);

        byte[] pngBytes;
        DestroyThisData();
        pngBytes = getMap(map.id);
        Data.getDataClass().selectedMap = map;
        tex.LoadImage(pngBytes);
        GetComponent<Renderer>().material.mainTexture = tex;
        gameObject.transform.localScale = new Vector3(tex.width, tex.height, 1);

        Joystick joy = joystick.GetComponent<Joystick>();
        joy.Camera.transform.position = new Vector3(0, 0, -tex.height + (tex.height / 7));
        var maps = DataReader.GetDataReader().selectedMap;
        if (map != null)
        {
            PointController pc = new PointController();
            var list = pc.getPoints(map.id);
            foreach (var pointObj in list)
            {
                GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
                pointObj script = point.GetComponent<pointObj>();
                script.SetPoint(pointObj);
                objList.Add(point);

                point.transform.parent = this.gameObject.transform;
                point.transform.localScale = new Vector3(pointObj.size_w, pointObj.size_h, (float)2);
                point.transform.localPosition = new Vector3(pointObj.x, pointObj.y, (float)0);
            }
        }

    }

    private void DestroyThisData()
    {
        foreach (GameObject go in objList)
        {
            Destroy(go);
        }
        objList.Clear();
    }

    private byte[] getMap(int id)
    {
        MapsController mc = new MapsController();
        return mc.sendMapOUT(id);
    }
}
