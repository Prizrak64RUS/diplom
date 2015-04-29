using UnityEngine;
using System.Collections;
using Assets.myScript.button;
using System.Collections.Generic;
using Assets.myScript.interfaceUrl;
using Assets.myScript.entity;

public class MapsRoot : MonoBehaviour {

    public RectTransform mapsTablePanel;
    public RectTransform mapsPanel;
    public List<GameObject> objList;
    public List<GameObject> objListEvent;

    public List<rowsMaps> rowsList;

    public GameObject Content;
    public GameObject ContentEvent;
    public UnityEngine.UI.Text error;

    void Start() {
        rowsList = new List<rowsMaps>();
        objListEvent = new List<GameObject>();
        objList = new List<GameObject>();
        EventMapsDelete += ButtonDelete;
    }

    public delegate void mapsDeeteDelegate(rowsMaps rows, GameObject o);
    public static event mapsDeeteDelegate EventMapsDelete;
    public static void CallMapsDeleteChanged(rowsMaps ru, GameObject o)
    {
        var handler = EventMapsDelete;
        if (EventMapsDelete != null) // если есть подписчики
        {
            EventMapsDelete(ru, o);
        }
    }

    public void ButtonMapsRead()
    {
        ButtonClass.exchange(mapsPanel, mapsTablePanel);
    }

    public void ButtonPointRead()
    {
        Application.LoadLevel("pointReader");
    }

    public void ButtonAdd() {
        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsMap")));
        rowsMaps script = rows.GetComponent<rowsMaps>();
        //script.events = new Assets.myScript.entity.Event();
        //script.events.id = 0;
        //script.isActiv.isOn = false;
        rows.transform.parent = Content.transform;
        //rowstList.Add(script);
        objList.Add(rows);
        
        rowsList.Add(script);
        script.map = new Maps("",0,"",0);
    }

    public void ButtonGet() {
        destroyAll();
        EventController ec = new EventController();
        MapsController mc = new MapsController();
        List<Assets.myScript.entity.Event> events = ec.getEvents();
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
            foreach (Assets.myScript.entity.Event e in events)
            {
                if(e.id==m.id_event)
                    script.type.text = e.name;
                    
            }
            script.name.text = m.name;
            script.description.text = m.description;
            rows.transform.parent = Content.transform;
            objList.Add(rows);

            rowsList.Add(script);
            script.map = m;
        }
    }

    public void ButtonSend() { 
    
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
        rowsList=new List<rowsMaps>();
    }

    public void ButtonDelete(rowsMaps rm, GameObject o)
    {
        objList.Remove(o);
        Destroy(o);
    }
}
