using UnityEngine;
using System.Collections;
using System.IO;

public class test : MonoBehaviour {
    void Start() 
    {
        string[] sss = Directory.GetLogicalDrives();
       // string[] sss = Directory.GetDirectories("\\");
        //string[] ss = Directory.GetFiles("D:\\");
        //foreach(string s in ss)
        //    Debug.Log(s);
        foreach (string s in sss)
            Debug.Log(s);
    }
    public void ButtonVVVV()
    { 


    }
}
