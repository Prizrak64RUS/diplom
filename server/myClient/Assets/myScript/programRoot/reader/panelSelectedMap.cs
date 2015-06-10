using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;
using System;

public class panelSelectedMap : MonoBehaviour {

    public bool onMapNameSelectedDelegate2 = false;
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


    public delegate void mapNameSelectedDelegate2(bool val);
    public static event mapNameSelectedDelegate2 EventMapmapNameSelected2;
    public static void CallMapNameSelectedChanged2(bool val)
    {
        var handler = EventMapmapNameSelected2;
        if (EventMapmapNameSelected2 != null) // если есть подписчики
        {
            EventMapmapNameSelected2(val);
        }
    }

    public delegate void mapNameSelectedDelegate3(bool val);
    public static event mapNameSelectedDelegate3 EventMapmapNameSelected3;
    public static void CallMapNameSelectedChanged3(bool val)
    {
        var handler = EventMapmapNameSelected3;
        if (EventMapmapNameSelected3 != null) // если есть подписчики
        {
            EventMapmapNameSelected3(val);
        }
    }
    void Start()
    {
        objMapList = new List<GameObject>();
        
        EventMapmapNameSelected = null;
        EventMapmapNameSelected2 = null;
      //  EventMapmapNameSelected3 = null;

        EventMapmapNameSelected2 += SelectedPanel;
        EventMapmapNameSelected2 += ButtonContentMasterClassFromRead;
        EventMapmapNameSelected += SelectedPanel;
        EventMapmapNameSelected3 += SelectedPanel;

        gameObject.SetActive(false);
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
        List<Maps> mapsList = mc.getMaps(DataReader.GetDataReader().thisEv);
        if (mapsList == null || mapsList.Count == 0) 
        {
            gameObject.SetActive(false);
            return;
        }
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
        if (mapsList == null || mapsList.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
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


    public void ButtonContentProgram()
    {
        mapController.CallActivFieldChanged();
        gameObject.SetActive(true);
        foreach (GameObject g in objMapList)
        {
            Destroy(g);
        }
        objMapList.Clear();
        var d = Data.getDataClass();
        d.getEventThis();
        List<Maps> mapsList = d.getMaps();
        if (mapsList.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        try
        {
            foreach (Assets.myScript.entity.Maps m in mapsList)
            {
                if (d.selectedMap != null && m.id == d.selectedMap.id) continue;
                GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedMapProgram")));
                buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                script.text.text = m.name;
                script.map = m;
                rows.transform.parent = Content.transform;
                objMapList.Add(rows);
            }
        }
        catch (Exception e) 
        {
            mapController.CallActivFieldChanged();
            gameObject.SetActive(false);
        }
    }

    public void ButtonContentUser()
    {
        gameObject.SetActive(true);
        if (objMapList.Count == 0)
        {
            var d = Data.getDataClass();
            while (d.getUsers() == null)
            {
            }
            List<User> list = d.getUsers();
            if (list.Count == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            try
            {
                foreach (Assets.myScript.entity.User u in list)
                {
                    if (u.id == Data.getDataClass().user.id || u.role.Equals(UserRole.ADMIN)) continue;
                    GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedUser")));
                    buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                    script.text.text = u.name;
                    rows.transform.parent = Content.transform;
                    objMapList.Add(rows);
                }
                {
                    GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedUser")));
                    buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                    script.text.text = "Всем";
                    rows.transform.parent = Content.transform;
                    objMapList.Add(rows);
                }
            }
            catch (Exception e)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ButtonContentEvent()
    {
        gameObject.SetActive(true);
        if (objMapList.Count == 0)
        {
            EventController ec = new EventController();
            List<Assets.myScript.entity.Event> list = null;
            while (list == null)
            {
                list = ec.getEvents();
            }
            if (list.Count == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            try
            {
                foreach (Assets.myScript.entity.Event u in list)
                {
                    GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedEventFromGenerator")));
                    buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                    script.text.text = u.name;
                    script.ev = u;
                    rows.transform.parent = Content.transform;
                    objMapList.Add(rows);
                }
            }
            catch (Exception e)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ButtonContentEvent1()
    {
        gameObject.SetActive(true);
        foreach (var o in objMapList)
            Destroy(o);
        objMapList.Clear();

            EventController ec = new EventController();
            List<Assets.myScript.entity.Event> list = null;
            while (list == null)
            {
                list = ec.getEvents();

            }
            if (list.Count == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            try
            {
                foreach (Assets.myScript.entity.Event u in list)
                {
                    GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedEvent1")));
                    buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                    script.text.text = u.name;
                    script.ev = u;
                    rows.transform.parent = Content.transform;
                    objMapList.Add(rows);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                gameObject.SetActive(false);
            }
    }

    public void ButtonContentEvent2()
    {
        gameObject.SetActive(true);
        foreach (var o in objMapList)
            Destroy(o);
        objMapList.Clear();

        EventController ec = new EventController();
        List<Assets.myScript.entity.Event> list = null;
        while (list == null)
        {
            list = ec.getEvents();

        }
        if (list.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        try
        {
            foreach (Assets.myScript.entity.Event u in list)
            {
                GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedEvent2")));
                buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                script.text.text = u.name;
                script.ev = u;
                rows.transform.parent = Content.transform;
                objMapList.Add(rows);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            gameObject.SetActive(false);
        }
    }

    public void ButtonContentMasterClassFromRead(bool l)
    {
        if (onMapNameSelectedDelegate2 == false||l==false) return;
        gameObject.SetActive(true);
        if (objMapList.Count == 0)
        {
            MasterclassController mc = new MasterclassController();
            List<Masterclass> list = null;
            while (list == null)
            {
                list = mc.getMasterclass(DataReader.GetDataReader().thisEv.id);
            }
            if (list.Count == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            try
            {
                foreach (Assets.myScript.entity.Masterclass u in list)
                {
                    GameObject rows = (GameObject)Instantiate(Resources.Load(("selectedMasterClassFromRead")));
                    buttonSelectedMap script = rows.GetComponent<buttonSelectedMap>();
                    script.text.text = u.name;
                    //script.mc = u;
                    rows.transform.parent = Content.transform;
                    objMapList.Add(rows);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                gameObject.SetActive(false);
            }
        }
    }
}
