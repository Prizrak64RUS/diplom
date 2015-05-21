﻿using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityStandardAssets.CrossPlatformInput;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;
using Assets.myScript;
using System;

public class mapController : MonoBehaviour {


    List<GameObject> objList;
    List<pointProgram> pointList;
    GameObject selectedObj;
    pointProgram selectedObjScript;
    public GameObject PointYoystick;

    void Start()
    {

        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING)) { ws = new WaitForSeconds(20); }
        DataReader.Clear();
        objList = new List<GameObject>();
        pointList = new List<pointProgram>();
        EventMapBuild += CreateField;
        EventActivField += ActivField;
        EventAddPointMap += AddPointMap;
        EventOkOrCancelPointMap += OkPointMap;
        EventUpOrDownSizePointMap += UpOrDownSizePoint;
        if (Data.getDataClass().selectedMap != null) 
        {
            CreateField(Data.getDataClass().selectedMap);
        }
    }

    public GameObject joystick;

    public delegate void addPointMapDelegate(pointProgram scr);
    public static event addPointMapDelegate EventAddPointMap;
    public static void CallAddPointMapChanged(pointProgram scr)
    {
        var handler = EventAddPointMap;
        if (EventAddPointMap != null) // если есть подписчики
        {
            EventAddPointMap(scr);
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

    void ActivField()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void UpOrDownSizePoint(bool isUp, bool isHorizontal)
    {
        if (selectedObj == null) return;
        float x, y;
        x = selectedObj.transform.localScale.x;
        y = selectedObj.transform.localScale.y;
        if (isHorizontal)
        {
            if (isUp)
            {
                if (x > 0.5) return;
                x += (float)0.02;
                selectedObj.transform.localScale = new Vector3(x, y, 2);
            }
            else
            {
                if (x < 0.04) return;
                x -= (float)0.02;
                selectedObj.transform.localScale = new Vector3(x, y, 2);
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

    void OkPointMap(bool isOk) 
    {
        Data.getDataClass().isRead = false;
        if (isOk)
        {
            ActivJoystick(false);
            var list = new List<Point>();
            int mapId = Data.getDataClass().selectedMap.id;

            var point = selectedObjScript.GetPoint();
            point.id_map = mapId;
            point.size_h = selectedObj.transform.localScale.y;
            point.size_w = selectedObj.transform.localScale.x;
            point.x = selectedObj.transform.localPosition.x;
            point.y = selectedObj.transform.localPosition.y;

            list.Add(point);
            PointController pc = new PointController();
            pc.setPoints(list);

            Destroy(selectedObj);
            selectedObj = null;
            selectedObjScript = null;
        }
        else
        {
            Destroy(selectedObj);
            selectedObj = null;
            selectedObjScript = null;
            ActivJoystick(false);
        }
    }

    void CreateField(Maps map)
    {
        StopCoroutine("AutoPointGet");
        var tex = new Texture2D(2, 2);
        byte[] pngBytes = FileController.getFile(map.id);
        DestroyThisData();
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
            var list = pc.getPoints(Data.getDataClass().user.role, map.id);
            foreach (var pointObj in list)
            {
                GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
                point.AddComponent<pointProgram>();
                pointProgram script = point.GetComponent<pointProgram>();
                pointList.Add(script);
                script.SetPoint(pointObj);
                objList.Add(point);

                point.transform.parent = this.gameObject.transform;
                point.transform.localScale = new Vector3(pointObj.size_w, pointObj.size_h, (float)2);
                point.transform.localPosition = new Vector3(pointObj.x, pointObj.y, (float)0);
            }
            StartCoroutine("AutoPointGet");

        }

    }

    void AddPointMap(pointProgram src)
    {
        Data.getDataClass().isRead = true;
        if (src == null)
        {
            GameObject point = (GameObject)Instantiate(Resources.Load(("point")));
            point.AddComponent<pointProgram>();
            pointProgram script = point.GetComponent<pointProgram>();
            Point p = null;
            switch (Data.getDataClass().user.role)
            {
                case UserRole.HEAD:
                    p = new Point(PointType.PORTER_POSITION);
                    break;
                case UserRole.PORTER:
                    p = new Point(PointType.GROUP);
                    break;
            }
            script.SetPoint(p);


            point.transform.parent = this.gameObject.transform;
            point.transform.localScale = new Vector3((float)0.02, (float)0.02, (float)2);
            point.transform.localPosition = Vector3.zero;
            SelectedPoint(point, script);
        }
        else 
        {
            StopCoroutine("AutoPointGet");
            GameObject point = src.gameObject;
            var list = new List<Point>();

            list.Add(src.GetPoint());
            PointController pc = new PointController();
            pc.delPoints(list);

            objList.Remove(src.gameObject);
            pointList.Remove(src);

            ActivJoystick(true);
            programButtomReaderSetting.CallButtonActivChanged(true);

            SelectedPoint(src.gameObject, src);
            StartCoroutine("AutoPointGet");
        }
    }

    void SelectedPoint(GameObject obj, pointProgram script)
    {
        selectedObjScript = script;
        selectedObj = obj;
        Joy2.point = selectedObj;
        ActivJoystick(true);
    }

    void ActivJoystick(bool val)
    {
        PointYoystick.SetActive(val);
    }

    WaitForSeconds ws = new WaitForSeconds(2);
    private IEnumerator AutoPointGet()
    {
            while (true)
            {
                PointController pc = new PointController();
                var list = pc.getPoints(Data.getDataClass().user.role, Data.getDataClass().selectedMap.id);
                foreach (var point in list)
                {
                    bool isOk = false;
                    foreach (var pointObj in pointList)
                    {
                        if (pointObj.GetPoint().Equals(point))
                        {
                            isOk = true;
                            break;
                        }

                        if (pointObj.GetPoint().id == point.id)
                        {
                            isOk = true;
                            pointObj.SetPoint(point);
                            break;
                        }
                    }
                    if (!isOk)
                    {
                        GameObject pointAdd = (GameObject)Instantiate(Resources.Load(("point")));
                        pointAdd.AddComponent<pointProgram>();
                        pointProgram script = pointAdd.GetComponent<pointProgram>();
                        pointList.Add(script);
                        script.SetPoint(point);
                        objList.Add(pointAdd);

                        pointAdd.transform.parent = this.gameObject.transform;
                        pointAdd.transform.localScale = new Vector3(point.size_w, point.size_h, (float)2);
                        pointAdd.transform.localPosition = new Vector3(point.x, point.y, (float)0);
                    }
                }

                List<pointProgram> p = new List<pointProgram>();
                foreach (var point in pointList)
                {
                    bool isOkP = false;
                    foreach (var pointObj in list)
                    {
                        if (pointObj.id == point.GetPoint().id)
                        {
                            isOkP = true;
                            break;
                        }
                    }
                    if (!isOkP)
                    {
                        p.Add(point);
                    }
                }
                foreach (var point in p)
                {
                    objList.Remove(point.gameObject);
                    pointList.Remove(point);
                    Destroy(point.gameObject);
                }
				yield return ws;
            }
    }

    private void DestroyThisData()
    {
        foreach (GameObject go in objList)
        {
            Destroy(go);
        }
        pointList.Clear();
        objList.Clear();
    }
}
