using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;

public class panelSelectedMap : MonoBehaviour {

    //public static UnityEngine.UI.Text textSelectedView;
    public GameObject Content;
    public List<GameObject> objMapList;

    public delegate void mapNameSelectedDelegate(bool val);
    public static event mapNameSelectedDelegate EventMapmapNameSelected;
    public static void CallMapNameSelectedChanged(bool val)
    {
        var handler = EventMapmapNameSelected;
        if (EventMapmapNameSelected != null) // если есть подписчики
        {
            EventMapmapNameSelected(val);
        }
    }
    void Start()
    {
        objMapList = new List<GameObject>();
        gameObject.SetActive(false);
        EventMapmapNameSelected += SelectedPanel;
    }
    public void SelectedPanel(bool val)
    {
        gameObject.SetActive(val);
    }

    public void ButtonContent()
    {
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
            rows.transform.parent = Content.transform;
            objMapList.Add(rows);
        }
    }

    public void ButtonContentDataRead()
    {
        foreach (GameObject g in objMapList)
        {
            Destroy(g);
        }
        objMapList.Clear();
        var dr = DataReader.GetDataReader();
        if (dr.selectedMap == null) {gameObject.SetActive(false); return; }
        MapsController mc = new MapsController();
        List<Maps> mapsList = mc.getMaps(new Assets.myScript.entity.Event(dr.selectedMap.id_event));
        DataReader.GetDataReader().mapListFromEvent = mapsList;
        foreach (Assets.myScript.entity.Maps m in mapsList)
        {
            if (m.id == dr.selectedMap.id) continue;
            GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedMapDataRead")));
            buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
            script.text.text = m.name;
            script.map = m;
            rows.transform.parent = Content.transform;
            objMapList.Add(rows);
        }
    }

}
