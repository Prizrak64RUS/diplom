using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityStandardAssets.CrossPlatformInput;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;

public class mapController : MonoBehaviour {


    List<GameObject> objList;
    List<pointProgram> pointList;
    static GameObject selectedObj;

    void Start()
    {
        DataReader.Clear();
        objList = new List<GameObject>();
        pointList = new List<pointProgram>();
        EventMapBuild += CreateField;
        EventActivField += ActivField;

        if (Data.getDataClass().selectedMap != null) 
        {
            CreateField(Data.getDataClass().selectedMap);
        }
    }

    public GameObject joystick;

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

    void CreateField(Maps map)
    {
        StopCoroutine("AutoPointGet");
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
            var list = pc.getPointsFromUserRole(Data.getDataClass().user.role, map.id);
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

    private IEnumerator AutoPointGet()
    {
            while (true)
            {
                PointController pc = new PointController();
                var list = pc.getPointsFromUserRole(Data.getDataClass().user.role, Data.getDataClass().selectedMap.id);
                foreach (var point in pointList) 
                {
                    bool isOk = false;
                    Point tmp = null;
                    foreach (var pointObj in list)
                    {
                        if (pointObj.Equals(point.GetPoint()))
                        {
                            isOk = true;
                            break;
                        }

                        if (pointObj.id == point.GetPoint().id)
                        {
                            isOk = true;
                            point.SetPoint(tmp); 
                            break;
                        }
                    }
                    if (!isOk) 
                    {
                        GameObject pointAdd = (GameObject)Instantiate(Resources.Load(("point")));
                        pointAdd.AddComponent<pointProgram>();
                        pointProgram script = pointAdd.GetComponent<pointProgram>();
                        pointList.Add(script);
                        script.SetPoint(tmp);
                        objList.Add(pointAdd);

                        pointAdd.transform.parent = this.gameObject.transform;
                        pointAdd.transform.localScale = new Vector3(tmp.size_w, tmp.size_h, (float)2);
                        pointAdd.transform.localPosition = new Vector3(tmp.x, tmp.y, (float)0);
                    }

                }
				yield return new WaitForSeconds(2);
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

    private byte[] getMap(int id)
    {
        MapsController mc = new MapsController();
        return mc.sendMapOUT(id);
    }
}
