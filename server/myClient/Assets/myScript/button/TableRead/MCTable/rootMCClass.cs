using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;
using Assets.myScript.button.TableRead;
using System;
using System.Threading;
using Assets.myScript.interfaceUrl;
public class rootMCClass : MonoBehaviour
{
    List<GameObject> objList;

    List<rowsMC> rowsList;
    List<Masterclass> delList;

    public GameObject Content;
    public UnityEngine.UI.Text error;

    MasterclassController ec;

    int idEv;

    public delegate void deleteDelegate(rowsMC rows);
    public static event deleteDelegate EventDelete;
    public static void CallDeleteChanged(rowsMC ru)
    {
        var handler = EventDelete;
        if (EventDelete != null) // если есть подписчики
        {
            EventDelete(ru);
        }
    }

    public delegate void setEvDelegate(int idM);
    public static event setEvDelegate EventSetEv;
    public static void CallSetEvChanged(int idM)
    {
        var handler = EventSetEv;
        if (EventSetEv != null) // если есть подписчики
        {
            EventSetEv(idM);
        }
    }

    void Start(){
        rowsList = new List<rowsMC>();
        objList = new List<GameObject>();
        delList = new List<Masterclass>();

        EventDelete += DeleteRows;
        EventSetEv += setEv;
        ec = new MasterclassController();
    }

    public void setEv(int idM)
    {
        idEv = idM;
    }

    public void ButtonSend() {
        if (!validData()) {
            return;
        }
        List<Masterclass> setList = new List<Masterclass>();
        List<Masterclass> updList = new List<Masterclass>();
        foreach (rowsMC re in rowsList)
        {
            if (re.mc.id == 0)
            {
                re.mc.name = re.name.text;
                re.mc.decription = re.description.text;
                re.mc.lecturer1 = re.lec1.text;
                re.mc.lecturer2 = re.lec2.text;
                re.mc.lecturer3 = re.lec3.text;
                setList.Add(re.mc);
            }
            else
            {
                re.mc.name = re.name.text;
                re.mc.decription = re.description.text;
                re.mc.lecturer1 = re.lec1.text;
                re.mc.lecturer2 = re.lec2.text;
                re.mc.lecturer3 = re.lec3.text;
                updList.Add(re.mc);
            }

        }
        ec.delMasterclass(delList);
        ec.updMasterclass(updList);
        ec.setMasterclass(setList);
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

         List<Masterclass> thisList = ec.getMasterclass(idEv);
         while (thisList == null)
         {
             thisList = ec.getMasterclass(idEv);
         }
         foreach (Masterclass ev in thisList)
         {
             GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsMC")));
             rowsMC script = rows.GetComponent<rowsMC>();
             script.setMC(ev);
             script.thisRows = script;

             rows.transform.parent = Content.transform;
             objList.Add(rows);
             rowsList.Add(script);
         }
    }

    public void DeleteRows(rowsMC rows)
    {
        rowsList.Remove(rows);

        if (rows.mc.id != 0)
        {
            delList.Add(rows.mc);
        }
        objList.Remove(rows.gameObject);
        Destroy(rows.gameObject);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsMC")));
        rowsMC script = rows.GetComponent<rowsMC>();
        script.mc = new Assets.myScript.entity.Masterclass(idEv);

        rows.transform.parent = Content.transform;
        rowsList.Add(script);
        objList.Add(rows);
    }


    private bool validData() {

        foreach (rowsMC re in rowsList)
        {
            if (!re.name.text.Equals("") &&
                !re.description.text.Equals("")&&
                (!re.lec1.text.Equals("")||!re.lec2.text.Equals("")||
                !re.lec3.text.Equals("")))
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

}
