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

    public GameObject buttonAdd;
    public GameObject buttonOk;
    public GameObject buttonBreak;
    public GameObject buttonUpHorizontal;
    public GameObject buttonDownHorizontal;
    public GameObject buttonUpVertikal;
    public GameObject buttonDownVertikal;


    public GameObject ContentMap;
    public List<GameObject> objMapList;
    public void ButtonSetting() {
        Assets.myScript.button.ButtonClass.exchange(rootPanel, settingPanel);
    }

    void Start() 
    {
        objMapList = new List<GameObject>();
    }

    public void ButtonSelectedMapPanel() {
        foreach (GameObject g in objMapList)
        {
            Destroy(g);
        }
        objMapList.Clear();

        MapsController mc = new MapsController();
        List<Maps> mapsList = mc.getMaps();
        foreach (Assets.myScript.entity.Maps m in mapsList)
        {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedMap")));
            buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
            script.text.text = m.name;
            script.map = m;
            rows.transform.parent = ContentMap.transform;
            objMapList.Add(rows);
        }
    }

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
        Debug.Log(1);
        mapWriter.CallUpOrDownSizePointMapChanged(isUp, isHorizontal);
    }

    public void ButtonOkOrCancel(bool isOk)
    {
        mapWriter.CallOkOrCancelPointMapChanged(isOk);
    }

    public void ButtonAddPoint()
    {
        mapWriter.CallAddPointMapChanged();
    }


    public void ButtonActivPoint(bool val) { 
        buttonAdd.SetActive(!val);
        buttonOk.SetActive(val);
        buttonBreak.SetActive(val);
        buttonUpHorizontal.SetActive(val);
        buttonDownHorizontal.SetActive(val);
        buttonUpVertikal.SetActive(val);
        buttonDownVertikal.SetActive(val);
    }
}
