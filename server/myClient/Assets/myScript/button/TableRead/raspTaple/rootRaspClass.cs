using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;
using Assets.myScript.button.TableRead;
using System;
using System.Threading;
using Assets.myScript.interfaceUrl;
public class rootRaspClass : MonoBehaviour
{
    List<GameObject> objList;

    List<rowsRasp> rowsList;
    List<Schedulepoint> delList;

    public GameObject Content;
    public UnityEngine.UI.Text error;

    SchedulepointController ec;

    public int idPoint;

    public delegate void deleteDelegate(rowsRasp rows);
    public static event deleteDelegate EventDelete;
    public static void CallDeleteChanged(rowsRasp ru)
    {
        var handler = EventDelete;
        if (EventDelete != null) // если есть подписчики
        {
            EventDelete(ru);
        }
    }


    void Start(){
        rowsList = new List<rowsRasp>();
        objList = new List<GameObject>();
        delList = new List<Schedulepoint>();

        EventDelete += DeleteRows;
        ec = new SchedulepointController();
    }


    public void ButtonSend(int id)
    {
        if (!validData())
        {
            return;
        }
        List<Schedulepoint> setList = new List<Schedulepoint>();
        List<Schedulepoint> updList = new List<Schedulepoint>();
        foreach (rowsRasp re in rowsList)
        {
            if (re.sh.id == 0)
            {
                re.sh.id_point=id;
                re.sh.date_start=re.date.text;
                re.sh.time_start=re.time_start.text;
                re.sh.time_end=re.time_end.text;
                foreach(var val in DataReader.GetDataReader().getMasterclassArr())
                {
                    if(val.name.Equals(re.mc.text))
                        re.sh.id_masterclass=val.id;
                }
                setList.Add(re.sh);
            }
            else
            {
                re.sh.id_point = id;
                re.sh.date_start = re.date.text;
                re.sh.time_start = re.time_start.text;
                re.sh.time_end = re.time_end.text;
                foreach (var val in DataReader.GetDataReader().getMasterclassArr())
                {
                    if (val.name.Equals(re.mc.text))
                        re.sh.id_masterclass = val.id;
                }
                updList.Add(re.sh);
            }

        }
        ec.delSchedulepoint(delList);
        ec.updSchedulepoint(updList);
        ec.setSchedulepoint(setList);
        destroyAll();
    }

    public void AllDelete()
    {
        foreach (rowsRasp re in rowsList)
        {
            if (re.sh.id != 0)
            {
                delList.Add(re.sh);
            }
            ec.delSchedulepoint(delList);
            destroyAll();
        }

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

         List<Schedulepoint> thisList = ec.getSchedulepoint(idPoint);
         while (thisList == null)
         {
             thisList = ec.getSchedulepoint(idPoint);
         }
         foreach (Schedulepoint ev in thisList)
         {
             GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsRasp")));
             rowsRasp script = rows.GetComponent<rowsRasp>();
             script.setMC(ev);
             script.thisRows = script;

             rows.transform.parent = Content.transform;
             objList.Add(rows);
             rowsList.Add(script);
         }
    }

    public void DeleteRows(rowsRasp rows)
    {
        rowsList.Remove(rows);

        if (rows.sh.id != 0)
        {
            delList.Add(rows.sh);
        }
        objList.Remove(rows.gameObject);
        Destroy(rows.gameObject);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsRasp")));
        rowsRasp script = rows.GetComponent<rowsRasp>();
        script.sh = new Assets.myScript.entity.Schedulepoint();

        rows.transform.parent = Content.transform;
        rowsList.Add(script);
        objList.Add(rows);
    }


    private bool validData() {

        //foreach (rowsRasp re in rowsList)
        //{
        //    if (!re.name.text.Equals("") &&
        //        !re.description.text.Equals("")&&
        //        (!re.lec1.text.Equals("")||!re.lec2.text.Equals("")||
        //        !re.lec3.text.Equals("")))
        //    {

        //    }
        //    else
        //    {
        //        //Debug.Log(!re.name.text.Equals("") +"  "+
        //        //!re.description.text.Equals("") + "  " +
        //        //validDate(re.date.text)); 
        //        return false; }
        //}
        return true;
    }

}
