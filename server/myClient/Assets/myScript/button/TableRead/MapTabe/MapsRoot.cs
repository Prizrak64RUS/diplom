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

    public GameObject Content;
    public GameObject ContentEvent;
    public UnityEngine.UI.Text error;

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
        //rowsEvent script = rows.GetComponent<rowsEvent>();
        //script.events = new Assets.myScript.entity.Event();
        //script.events.id = 0;
        //script.isActiv.isOn = false;
        rows.transform.parent = Content.transform;
        //rowstList.Add(script);
        objList.Add(rows);
    }

    public void ButtonGet() {
        EventController ec = new EventController();
        MapsController mc = new MapsController();
        List<Assets.myScript.entity.Event> events = ec.getEvents();
        foreach (Assets.myScript.entity.Event e in events) {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedEvent")));
            rows.GetComponentInChildren<UnityEngine.UI.Text>().text = e.name;
            rows.transform.parent = ContentEvent.transform;
        }
        List<Maps> maps = mc.getMaps();
    }
}
