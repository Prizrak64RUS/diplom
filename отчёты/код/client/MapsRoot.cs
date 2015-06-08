using UnityEngine;
using System.Collections;
using Assets.myScript.button;
using System.Collections.Generic;
using Assets.myScript.interfaceUrl;
using Assets.myScript.entity;

public class MapsRoot : MonoBehaviour {

    public RectTransform mapsTablePanel;
    public RectTransform mapsPanel;
     List<GameObject> objList;
     List<GameObject> objListEvent;

     List<rowsMaps> rowsList;
     List<Assets.myScript.entity.Event> events;
     List<Maps> delList;

    public GameObject Content;
    public GameObject ContentEvent;
    public UnityEngine.UI.Text error;

    void Start() {
        events = new List<Assets.myScript.entity.Event>();
        objList = new List<GameObject>();
        objListEvent = new List<GameObject>();
        rowsList = new List<rowsMaps>();
        delList = new List<Maps>();
        EventMapsDelete += ButtonDelete;
    }

    public delegate void mapsDeeteDelegate(rowsMaps rows);
    public static event mapsDeeteDelegate EventMapsDelete;
    public static void CallMapsDeleteChanged(rowsMaps rows)
    {
        var handler = EventMapsDelete;
        if (EventMapsDelete != null) // если есть подписчики
        {
            EventMapsDelete(rows);
        }
    }

    public void ButtonMapsRead()
    {
        ButtonClass.exchange(mapsPanel, mapsTablePanel);
    }

    //public void ButtonPointRead()
    //{
    //    Application.LoadLevel("pointReader");
    //}

    public void ButtonAdd() {
        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsMap")));
        rowsMaps script = rows.GetComponent<rowsMaps>();
        rows.transform.parent = Content.transform;
        objList.Add(rows);
        script.map = new Maps("", 0, "", 0);
        rowsList.Add(script);

    }

    public void ButtonGet() {
        destroyAll();
        EventController ec = new EventController();
        MapsController mc = new MapsController();
        events = ec.getEvents();
        foreach (Assets.myScript.entity.Event e in events) {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedEvent")));
            rows.GetComponentInChildren<UnityEngine.UI.Text>().text = e.name;
            rows.transform.parent = ContentEvent.transform;
            objListEvent.Add(rows);
        }
        List<Maps> maps = mc.getMaps();
        foreach (Assets.myScript.entity.Maps m in maps)
        {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsMap")));
            rowsMaps script = rows.GetComponent<rowsMaps>();

            script.type.text = GetNameForId(events, m.id_event);
            script.name.text = m.name;
            script.description.text = m.description;
            rows.transform.parent = Content.transform;
            objList.Add(rows);
            script.map = m;
            rowsList.Add(script);
        }
    }

    public void ButtonSend() {
        List<Maps> updList = new List<Maps>();
        List<Maps> setList = new List<Maps>();
        foreach (rowsMaps rows in rowsList)
        {
            if (rows.map.id == 0)
            {
                rows.map.id_event = GetIdForName(events, rows.type.text);
                rows.map.name = rows.name.text;
                rows.map.description = rows.description.text;
                setList.Add(rows.map);
            }
            else 
            {
                rows.map.id_event = GetIdForName(events, rows.type.text);
                rows.map.name = rows.name.text;
                rows.map.description = rows.description.text;
                updList.Add(rows.map);
            }
        }
        MapsController mc = new MapsController();
        mc.delMap(delList);
        mc.setMap(setList);
        mc.updMap(updList);
        destroyAll();
    
    }


    private string GetNameForId(List<Assets.myScript.entity.Event> events, int id)
    {
        foreach (Assets.myScript.entity.Event e in events)
        {
            if (e.id == id)
                return e.name;

        }
        return null;
    }

    private int GetIdForName(List<Assets.myScript.entity.Event> events, string name)
    {
        foreach (Assets.myScript.entity.Event e in events)
        {
            if (e.name == name)
                return e.id;

        }
        return 0;
    }


    public void destroyAll()
    {
        foreach (GameObject o in objList)
        {
            Destroy(o);
        }
        foreach (GameObject o in objListEvent)
        {
            Destroy(o);
        }
        objList.Clear();
        objListEvent.Clear();
        rowsList.Clear();
        delList.Clear();
        events.Clear();

    }

    public void ButtonDelete(rowsMaps rows)
    {
        if (rows.map.id != 0)
        {
            delList.Add(rows.map);
        }
        rowsList.Remove(rows);
        objList.Remove(rows.thisR);
        Destroy(rows.thisR);
    }
}
