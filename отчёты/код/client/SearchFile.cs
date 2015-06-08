using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Assets.myScript;
using UnityEngine.UI;

public class SearchFile : MonoBehaviour {
    public GameObject Content;
    public GameObject thisObject;
    private List<GameObject> objList;
    private List<string> patch;
    private string[] arrPatch;
    private char[] separator;

    public delegate void mapFileNextDelegate(string val);
    public static event mapFileNextDelegate MapFileNextDelete;
    public static void CallMapFileNextChanged(string val)
    {
        var handler = MapFileNextDelete;
        if (MapFileNextDelete != null) // если есть подписчики
        {
            MapFileNextDelete(val);
        }
    }

    public delegate void mapFileOkDelegate(string val);
    public static event mapFileOkDelegate MapFileOkDelegate;
    public static void CallMapFileOkChanged(string val)
    {
        var handler = MapFileOkDelegate;
        if (MapFileOkDelegate != null) // если есть подписчики
        {
            MapFileOkDelegate(val);
        }
    }

    void Start()
    {
        MapFileNextDelete += ButtonNext;
        MapFileOkDelegate += ButtonOK;
        patch = new List<string>();
        objList = new List<GameObject>();
        separator = new char[1];
        
        loadRoot();

    }
    public void ButtonNext(string val)
    {
        DestroyList();
        patch.Add(val);
        arrPatch = patch.ToArray();
        loadOld();
//#if UNITY_STANDALONE_WIN   
//#endif
//#if UNITY_ANDROID
//#endif
    }
    public void ButtonBreak()
    {
        DestroyList();
//#if UNITY_STANDALONE_WIN
        if (patch.Count <= 1)
        {
            if (patch.Count == 0) { loadRoot(); }
            else
            {
                patch.Remove(arrPatch[arrPatch.Length - 1]);
                arrPatch = patch.ToArray();
                loadRoot();
            }
        }
        else {
            patch.Remove(arrPatch[arrPatch.Length - 1]);
            arrPatch = patch.ToArray();
            loadOld();
        }
//#endif
//#if UNITY_ANDROID
//        if (patch.Count <= 2)
//        {
//            if (patch.Count == 1) { loadRoot(); }
//            else
//            {
//                patch.Remove(arrPatch[arrPatch.Length - 1]);
//                arrPatch = patch.ToArray();
//                loadRoot();
//            }
//        }
//        else {
//            patch.Remove(arrPatch[arrPatch.Length - 1]);
//            arrPatch = patch.ToArray();
//            loadOld();
//        }
//#endif

    }
    public void ButtonOK(string val)
    {
        string p = getPatch();
#if UNITY_STANDALONE_WIN  
        val = p + val;
#endif
#if UNITY_ANDROID
        val = p +separator[0]+ val;
#endif
        ButtonDestroyThis();
        mapWriter.CallMapBuildChanged(val, null);
    }

    private void loadRoot() {
         string[] sss;
#if UNITY_STANDALONE_WIN
         sss = Directory.GetLogicalDrives();
         separator[0]='\\';
#endif
#if UNITY_ANDROID
        sss = Directory.GetDirectories("/");
        separator[0]='/';
        //if(patch.Count==0){
        //    patch.Add("/");
        //}
#endif
        foreach (string s in sss)
        {
            GameObject element = (GameObject)Instantiate(Resources.Load(("elementSearch")));
            ElementFile ef = element.GetComponent<ElementFile>();
            ef.isFile = false;
            element.GetComponentInChildren<UnityEngine.UI.Text>().text = s;
            element.transform.parent = Content.transform;
            objList.Add(element);
        }
    }
    private void loadOld()
    {
        string p = getPatch();
        
        try
        {
            string[] sss = Directory.GetDirectories(p);

            foreach (string s in sss)
            {
                GameObject element = (GameObject)Instantiate(Resources.Load(("elementSearch")));
                ElementFile ef = element.GetComponent<ElementFile>();
                ef.isFile = false;
                string[] size = s.Split(separator);
                element.GetComponentInChildren<UnityEngine.UI.Text>().text = size[size.Length - 1];
                element.transform.parent = Content.transform;
                objList.Add(element);
            }
            sss = Directory.GetFiles(p, "*.png");
            foreach (string s in sss)
            {
                GameObject element = (GameObject)Instantiate(Resources.Load(("elementSearch")));
                ElementFile ef = element.GetComponent<ElementFile>();
                ef.isFile = true;
                string[] size = s.Split(separator);
                element.GetComponentInChildren<UnityEngine.UI.Text>().text = size[size.Length - 1];
                element.transform.parent = Content.transform;
                objList.Add(element);
            }
        }
        catch (System.Exception e) { patch.Clear(); arrPatch = null; loadRoot(); }
    }

    private string getPatch() {
        string p = "";
//#if UNITY_STANDALONE_WIN
        p += arrPatch[0];
        for (int i = 1; i < arrPatch.Length; i++)
        {
//#endif
#if UNITY_ANDROID
//        p += arrPatch[0] + arrPatch[1];
//        for (int i = 2; i < arrPatch.Length; i++) {
            p += separator[0];
#endif



            p += arrPatch[i] + separator[0];
        }
        return p;
    }

    public void ButtonDestroyThis() 
    {
        DestroyList();
        patch = new List<string>();
        objList = new List<GameObject>();
        separator = new char[1];
        thisObject.SetActive(false);
        loadRoot();
    }

    private void DestroyList() {
        foreach (GameObject o in objList)
            Destroy(o);
    }
}
