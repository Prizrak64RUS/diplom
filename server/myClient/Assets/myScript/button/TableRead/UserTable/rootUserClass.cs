using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;
using Assets.myScript.button.TableRead;
using System;
using Assets.myScript.interfaceUrl;
public class rootUserClass : MonoBehaviour {
    List<GameObject> objList;
    List<rowsUser> rowsList;
    List<User> delList;
    //public List<User> usrList;
    //public List<User> setUsrList;
    //public List<User> updUsrList;
    //public List<User> delUsrList;

    public GameObject Content;

    public RectTransform rootPanel;
    public RectTransform readPanel;


    public UnityEngine.UI.InputField greadebook;
    public UnityEngine.UI.InputField name;
    public UnityEngine.UI.Text role;
    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.InputField login;
    public UnityEngine.UI.InputField password;


    UserController uc;

    /// <summary>
    /// Событие, на него будут подписываться все желающие
    /// </summary>
    public delegate void userReadDelegate(rowsUser ru);
    public delegate void userDeeteDelegate(rowsUser rows);
    public static event userReadDelegate EventUserRead;
    public static event userDeeteDelegate EventUserDelete;

    public static void CallUserReadChanged(rowsUser ru)
    {
        var handler = EventUserRead;
        if (EventUserRead != null) // если есть подписчики
            EventUserRead(ru);
    }
    public static void CallUserDeleteChanged(rowsUser rows)
    {
        var handler = EventUserDelete;
        if (EventUserDelete != null) // если есть подписчики
            EventUserDelete(rows);
    }
   
    void Start(){
        objList = new List<GameObject>();
        rowsList=new List<rowsUser>();
        delList=new List<User>();
        uc = new UserController();
        EventUserRead += startReader;
        EventUserDelete += DeleteRows;
    }


    private rowsUser rows;
    public void startReader(rowsUser ru) {
        ButtonClass.exchange(rootPanel, readPanel);
        writeField(ru.user);
        rows = ru;
    }
    
    public void ButtonReaderBreak(){
        ButtonClass.exchange(rootPanel, readPanel);
    }

    public void ButtonReaderOk()
    {
        if(description.text!=""&&login.text !=""&& password.text !=""&&
            role.text != "NONE" && greadebook.text != "" && greadebook.text != "0" && name.text != "")
        {
        writeUser(rows.user);       
        rows.greadebook.text = greadebook.text;
        rows.name.text = name.text;
        ButtonClass.exchange(rootPanel, readPanel);
        }
    }

    public void ButtonSend() {
        List<User>setList=new List<User>();
        List<User> updList=new List<User>();
        foreach (rowsUser rows in rowsList)
        {
            if (rows.user.id == 0)
            {
                Debug.Log(1);
                if (rows.greadebook.text != 0 + "")
                {
                    Debug.Log(2);
                    setList.Add(rows.user);
                }
            }
            else
            {
                updList.Add(rows.user);
            }
        }
        uc.deleteUsers(delList);
        uc.updateUsers(updList);
        uc.setUsers(setList);
        destroyAll();
    }
    public void ButtonGet() {
         destroyAll();
         List<User> usrList = uc.getUsers();
         if (usrList == null) {
             return;
         }
         foreach (User usr in usrList) {
             GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsUser")));
             rowsUser script = rows.GetComponent<rowsUser>();
             script.greadebook.text =""+ usr.gradebook;
             script.name.text = usr.name;
             script.user = usr;
             rowsList.Add(script);
             rows.transform.parent = Content.transform;
             objList.Add(rows);
         }
    }

    private void writeField(User usr) {
        description.text = usr.description;
        login.text = usr.login;
        password.text = usr.password;
        name.text = usr.name;
        greadebook.text = usr.gradebook + "";
        
        switch (usr.role) { 
            case "ADMIN":
                role.text = "Администратор";
                break;
            case "HEAD":
                role.text = "Управляющий";
                break;
            case "GUIDES":
                role.text = "Гид";
                break;
            case "PORTER":
                role.text = "Встречающий";
                break;
        }
    }
    private void writeUser(User usr)
    {
         usr.description = description.text;
        usr.login=login.text ;
        usr.password=password.text;
         usr.name = name.text;
         usr.gradebook =Int32.Parse(greadebook.text);

         switch (role.text)
         {
             case "Администратор":
                 usr.role = "ADMIN";
                 break;
             case "Управляющий":
                 usr.role = "HEAD";
                 break;
             case "Гид":
                 usr.role = "GUIDES";
                 break;
             case "Встречающий":
                 usr.role = "PORTER";
                 break;
         }
    }


    public void DeleteRows(rowsUser rows)
    {
        if (rows.user.id != 0) 
        {
            delList.Add(rows.user);
        }
        rowsList.Remove(rows);
        objList.Remove(rows.thisRows);
        Destroy(rows.thisRows);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsUser")));
        rowsUser script = rows.GetComponent<rowsUser>();
        script.user = new User();
        rowsList.Add(script);
        rows.transform.parent=Content.transform;
        objList.Add(rows);
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

}
