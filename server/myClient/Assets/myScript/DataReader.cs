using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using System.Collections.Generic;

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

    public bool isRead = false;
    private DataReader() { }
    public List<Maps> mapListFromEvent { get; set; }
    public string patch { get; set; }
    public Maps selectedMap { get; set; }
}
