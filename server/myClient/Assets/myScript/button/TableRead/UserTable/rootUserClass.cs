using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;

public class rootUserClass : MonoBehaviour {
    public List<GameObject> objList;
    public List<User> usrList;

    public GameObject Content;

    public RectTransform rootPanel;
    public RectTransform readPanel;

    public UnityEngine.UI.InputField greadebook;
    public UnityEngine.UI.InputField name;
    public UnityEngine.UI.InputField role;
    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.InputField login;
    public UnityEngine.UI.InputField password;

    /// <summary>
    /// Событие, на него будут подписываться все желающие
    /// </summary>
    public delegate void userReadDelegate(rowsUser ru);
    public delegate void userDeeteDelegate(GameObject ru);
    public static event userReadDelegate EventUserRead;
    public static event userDeeteDelegate EventUserDelete;
    public static void CallUserReadChanged(rowsUser ru)
    {
        var handler = EventUserRead;
        if (EventUserRead != null) // если есть подписчики
            EventUserRead(ru);
    }
    public static void CallUserDeleteChanged(GameObject ru)
    {
        var handler = EventUserDelete;
        if (EventUserDelete != null) // если есть подписчики
            EventUserDelete(ru);
    }
   
    void Start(){
        //objList = new List<GameObject>();
        //usrList = new List<User>();
        EventUserRead += startReader;
        EventUserDelete += DeleteRows;
    }



    public void startReader(rowsUser ru) {
        ButtonClass.exchange(rootPanel, readPanel);
    }

    public void DeleteRows(GameObject ru)
    {
        objList.Remove(ru);
        Destroy(ru);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsUser")));
        rows.transform.parent=Content.transform;
    }

}
