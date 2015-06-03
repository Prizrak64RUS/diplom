using UnityEngine;
using System.Collections;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;
using Assets.myScript.entity;
using UnityStandardAssets.CrossPlatformInput;

public class settingButton : MonoBehaviour {

    public RectTransform rootPanel;
    public RectTransform settingPanel;
    public RectTransform searchFile;
    public RectTransform addData;
    PanelReadDataPoint scriptAddData;

    public GameObject buttonSetting;
    public GameObject buttonAdd;
    public GameObject buttonRead;
    public GameObject buttonOk;
    public GameObject buttonBreak;
    public GameObject buttonUpHorizontal;
    public GameObject buttonDownHorizontal;
    public GameObject buttonUpVertikal;
    public GameObject buttonDownVertikal;
    public GameObject buttonAddData;

    public GameObject ContentMap;
    public List<GameObject> objMapList;
    public void ButtonSetting() {
        mapWriter.CallActivFieldChanged();
        Assets.myScript.button.ButtonClass.exchange(rootPanel, settingPanel);
    }

    public void ButtonPanelReadActiv() 
    {
        scriptAddData.setPoint(mapWriter.GetSelectedObj().GetComponent<pointObj>().GetPoint());
        ReadDataPoint();
    }

    public void ButtonPanelReadUnActiv() 
    {
        Point point = scriptAddData.getPoint();
        point.id_map=DataReader.GetDataReader().selectedMap.id;
        if (point == null) return;
        Point p = null;
        if (point.id != 0) 
        {
            p = point;
        }
        else
        {

            PointController pc = new PointController();
            while (p == null)
                p = pc.setPoint(point);
            Debug.Log(p.id);
        }
        if (p.type != PointType.ACTION) { scriptAddData.rrc.AllDelete(); }
        else
        {
            scriptAddData.rrc.ButtonSend(p.id);
        }


        mapWriter.GetSelectedObj().GetComponent<pointObj>().SetPoint(p);
        ReadDataPoint();
    }

    public void ReadDataPoint()
    {
        mapWriter.CallActivFieldChanged();
        Assets.myScript.button.ButtonClass.exchange(rootPanel, addData);
    }

    void Start() 
    {
        scriptAddData = addData.GetComponent<PanelReadDataPoint>();
        objMapList = new List<GameObject>();
    }

    //public void ButtonSelectedMapPanel() {
    //    foreach (GameObject g in objMapList)
    //    {
    //        Destroy(g);
    //    }
    //    objMapList.Clear();

    //    MapsController mc = new MapsController();
    //    List<Maps> mapsList = mc.getMaps();
    //    foreach (Assets.myScript.entity.Maps m in mapsList)
    //    {
    //        GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedMap")));
    //        buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
    //        script.text.text = m.name;
    //        script.map = m;
    //        rows.transform.parent = ContentMap.transform;
    //        objMapList.Add(rows);
    //    }
    //}

    public void ButtonSelectedMapImage()
    {
        searchFile.transform.position = settingPanel.transform.position;
        searchFile.gameObject.SetActive(true);
    }

    public void ButtonSaveMap()
    {
        mapWriter.CallSaveMapChanged();
    }

    public void ButtonUpOrDown(int key) 
    {
        bool isUp=false, isHorizontal=false;
        switch (key) { 
            case 1:
                isUp = true;
                break;
            case 2:
                isHorizontal = true;
                break;
            case 3:
                isUp = true; isHorizontal= true;
                break;
            default:
                break;
        }
        mapWriter.CallUpOrDownSizePointMapChanged(isUp, isHorizontal);
    }

    public void ButtonOkOrCancel(bool isOk)
    {
        DataReader.GetDataReader().isRead = false;
        mapWriter.CallOkOrCancelPointMapChanged(isOk);
    }

    public void ButtonAddPoint()
    {
        if (DataReader.GetDataReader().selectedMap == null) return;
        DataReader.GetDataReader().isRead = true;
        mapWriter.CallAddPointMapChanged();
        ButtonPanelReadActiv();
    }


    public void ButtonActivPointRead(bool val) 
    {
        if (mapWriter.GetSelectedObj() == null) return;
        DataReader.GetDataReader().isRead = true;
        ButtonActivPoint(val);
    }

    public void ButtonActivPoint(bool val) {
        if (DataReader.GetDataReader().selectedMap == null) return;
        buttonSetting.SetActive(!val);
        buttonAdd.SetActive(!val);
        buttonRead.SetActive(!val);
        buttonOk.SetActive(val);
        buttonBreak.SetActive(val);
        buttonUpHorizontal.SetActive(val);
        buttonDownHorizontal.SetActive(val);
        buttonUpVertikal.SetActive(val);
        buttonDownVertikal.SetActive(val);
        buttonAddData.SetActive(val);
    }

    public void ButtonEnd()
    {
        Application.Quit();
    }
}
