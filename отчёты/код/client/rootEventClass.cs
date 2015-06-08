using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;
using Assets.myScript.button.TableRead;
using System;
using System.Threading;
using Assets.myScript.interfaceUrl;
public class rootEventClass : MonoBehaviour
{
    public List<GameObject> objList;

    public List<rowsEvent> rowsList;
    public List<Assets.myScript.entity.Event> delList;

    public GameObject Content;
    public UnityEngine.UI.Text error;

    EventController ec;

    public delegate void eventDeeteDelegate(rowsEvent rows);
    public static event eventDeeteDelegate EventEventDelete;
    public static void CallEventDeleteChanged(rowsEvent ru)
    {
        var handler = EventEventDelete;
        if (EventEventDelete != null) // если есть подписчики
        {
            EventEventDelete(ru);
        }
    }

    public delegate void eventSelectedDelegate(rowsEvent rows, bool val);
    public static event eventSelectedDelegate EventEventSelected;
    public static void CallEventSelectedChanged(rowsEvent rows, bool val)
    {
        var handler = EventEventSelected;
        if (EventEventSelected != null) // если есть подписчики
        {
            EventEventSelected(rows, val);
        }
    }

    void Start(){
        rowsList = new List<rowsEvent>();
        objList = new List<GameObject>();
        delList = new List<Assets.myScript.entity.Event>();

        EventEventDelete += DeleteRows;
        EventEventSelected += SelectedRows;
        ec = new EventController();
    }

    public void ButtonSend() {
        if (!validData()) {
            return;
        }
        List<Assets.myScript.entity.Event> setList = new List<Assets.myScript.entity.Event>();
        List<Assets.myScript.entity.Event> updList = new List<Assets.myScript.entity.Event>();
        foreach (rowsEvent re in rowsList)
        {
            if (re.events.id == 0)
            {
                re.events.name=re.name.text;
                re.events.isActiv = (re.isActiv.isOn) ? 1 : 0;
                re.events.description=re.description.text;
                re.events.date=re.date.text;
                setList.Add(re.events);
            }
            else 
            {
                //if (re.events.name.Equals(re.name.text) &&
                //    (re.events.isActiv==1)?true:false == re.isActiv.isOn &&
                //    re.events.description.Equals(re.description.text) &&
                //    re.events.date.Equals(re.date.text))
                //{
                //    continue;
                //}
                //else
                //{
                    re.events.name = re.name.text;
                    re.events.isActiv = (re.isActiv.isOn) ? 1 : 0;
                    re.events.description = re.description.text;
                    re.events.date = re.date.text;
                    updList.Add(re.events);
                //}
            }

        }
        ec.updEvents(delList);
        ec.updEvents(updList);
        ec.setEvent(setList);
        destroyAll();
    }


    public void destroyAll()
    {
        foreach (GameObject o in objList)
        {
            Destroy(o);
        }
        objList.Clear();
        rowsList.Clear();
        delList.Clear();

    }

    public void ButtonGet() {
         destroyAll();
         
         List<Assets.myScript.entity.Event> thisEvtList = ec.getEvents();
         if (thisEvtList == null) {
             return;
         }
         foreach (Assets.myScript.entity.Event ev in thisEvtList)
         {
             GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsEvent")));
             rowsEvent script = rows.GetComponent<rowsEvent>();
             script.date.text = ev.date;
             script.name.text = ev.name;
             script.description.text = ev.description;
             script.events = ev;
             script.isActiv.isOn = (ev.isActiv==1)?true:false;

             rows.transform.parent = Content.transform;
             objList.Add(rows);
             rowsList.Add(script);
         }
    }

    public void DeleteRows(rowsEvent rows)
    {
        rowsEvent script = rows.GetComponent<rowsEvent>();
        script.events.isDelete = 1;
        if(script.events.id!=0){
            delList.Add(script.events);
        }
        Destroy(rows.thisRows);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsEvent")));
        rowsEvent script = rows.GetComponent<rowsEvent>();
        script.events = new Assets.myScript.entity.Event();
        script.events.id = 0;
        script.isActiv.isOn = false;
        rows.transform.parent=Content.transform;
        rowsList.Add(script);
        objList.Add(rows);
    }

    public void SelectedRows(rowsEvent rows, bool val)
    {
        if (val)
        {
            foreach (rowsEvent rw in rowsList)
            {
                if (!rows.Equals(rw))
                    rw.isActiv.isOn = false;
            }
        }
        //rows.isActiv.isOn = true;
    }


    private bool validData() {

        foreach (rowsEvent re in rowsList) {
            if (!re.name.text.Equals("") &&
                !re.description.text.Equals("") &&
                validDate(re.date.text))
            {

            }
            else
            {
                //Debug.Log(!re.name.text.Equals("") +"  "+
                //!re.description.text.Equals("") + "  " +
                //validDate(re.date.text)); 
                return false; }
        }
        return true;
    }

    private bool validDate(string date) {
        string[] s = date.Split(('-'));
        try{
            if (s.Length != 3) {
                throw new Exception();
            }
            for (int i = 0; i < 3; i++) {
                Convert.ToInt32(s[i]);
            } 
            //if(DateTime.Now.Year>Convert.ToInt32(s[0]))
            //    throw new Exception();
        } catch (Exception e){
            return false;
        }
        return true;
    }

}
