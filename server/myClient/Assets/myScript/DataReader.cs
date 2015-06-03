using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using System.Collections.Generic;
using Assets.myScript.interfaceUrl;

public class DataReader {


    public static DataReader GetDataReader()
    {
        if (dataReader == null) { dataReader = new DataReader(); }
        return dataReader;
    }

    public static void Clear()
    {
        dataReader = null;
    }
    static DataReader dataReader;


    public Assets.myScript.entity.Event thisEv { get; set; }
    public bool isRead = false;
    private DataReader() {
        thisEv = new Assets.myScript.entity.Event(9);
    }

    public List<Masterclass> getMasterclassArr() 
    {
        if (ma == null) { MasterclassController mc = new MasterclassController(); ma = mc.getMasterclass(thisEv.id); }
        return ma;
    }

    List<Masterclass> ma;

    public List<Maps> mapListFromEvent { get; set; }
    public string patch { get; set; }
    public Maps selectedMap { get; set; }
}
