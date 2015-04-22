using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.entity;
using Assets.myScript.button;
using Assets.myScript.button.TableRead;
using System;
using Assets.myScript.interfaceUrl;
public class rootUserClass : MonoBehaviour {
    public List<GameObject> objList;

    public List<User> usrList;
    public List<User> setUsrList;
    public List<User> updUsrList;
    public List<User> delUsrList;

    public GameObject Content;

    public RectTransform rootPanel;
    public RectTransform readPanel;

    public UnityEngine.UI.InputField greadebook;
    public UnityEngine.UI.InputField name;
    public UnityEngine.UI.Text role;
    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.InputField login;
    public UnityEngine.UI.InputField password;
    public UnityEngine.UI.InputField type;


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

        uc = new UserController();
        //usrList = new List<User>();
        EventUserRead += startReader;
        EventUserDelete += DeleteRows;
    }


    private rowsUser rows;
    public void startReader(rowsUser ru) {
        ButtonClass.exchange(rootPanel, readPanel);
        greadebook.text = ru.greadebook.text;
        name.text = ru.name.text;
        rows = ru;
        switch (Convert.ToInt32(ru.type.text)) {
            case (int)EnumType.NULL:
                writeField(new User(), (int)EnumType.NULL);
                break;
            case (int)EnumType.READ:
                foreach(User usr in updUsrList){
                    if(greadebook.text.Equals(usr.gradebook+"")){
                        writeField(usr, (int)EnumType.READ);
                   break;
                    }
                }
                break;
            case (int)EnumType.REAL:
                foreach (User usr in usrList)
                {
                    if (greadebook.text.Equals(usr.gradebook+""))
                    {

                        writeField(usr, (int)EnumType.REAL);
                        break;
                    }
                }
                break;
            case (int)EnumType.SET:
                foreach (User usr in setUsrList)
                {
                    if (greadebook.text.Equals(usr.gradebook+""))
                    {
                        writeField(usr, (int)EnumType.SET);
                        break;
                    }
                }
                break;
        }
    }
    
    public void ButtonReaderBreak(){
        ButtonClass.exchange(rootPanel, readPanel);
    }

    public void ButtonReaderOk()
    {
        if(description.text!=""&&login.text !=""&& password.text !=""&&
            role.text != "NONE" && greadebook.text != ""&&name.text!="")
        {
            string tmpR="";
            switch (role.text)
            {
                case "Администратор":
                    tmpR = "ADMIN";
                    break;
                case "Управлящий":
                    tmpR = "HEAD";
                    break;
                case "Гид":
                    tmpR = "GIDES";
                    break;
                case "Встречающий":
                    tmpR = "PORTER";
                    break;
            }
            User us = new User(name.text, tmpR, description.text, login.text, Convert.ToInt32(greadebook.text), password.text);
            Debug.Log("ok");
        switch (Convert.ToInt32(type.text)) {
            case (int)EnumType.NULL:
                {
                    rows.type.text = "" + (int)EnumType.SET;
                    setUsrList.Add(us);
                    break;
                }
            case (int)EnumType.READ:
                {
                    rows.type.text = "" + (int)EnumType.READ;
                    User del = null;
                    foreach (User tmp in updUsrList)
                    {
                        if (tmp.gradebook == Convert.ToInt32(rows.greadebook.text))
                        {
                            del = tmp;
                        }
                    }
                   Debug.Log(del.id+"   2");
                    us.id = del.id;
                    updUsrList.Remove(del);
                    updUsrList.Add(us);
                    break;
                }
            case (int)EnumType.REAL:
                {
                    rows.type.text = "" + (int)EnumType.READ;
                    User del = null;
                    foreach (User tmp in usrList)
                    {
                        if (tmp.gradebook == Convert.ToInt32(rows.greadebook.text))
                        {
                            del = tmp;

                        }
                    }
                    Debug.Log(del.id);
                    us.id = del.id;
                    updUsrList.Add(us);
                    usrList.Remove(del);
                    break;
                }
            case (int)EnumType.SET:
                {
                    rows.type.text = "" + (int)EnumType.SET;
                    User del = null;
                    foreach (User tmp in setUsrList)
                    {
                        if (tmp.gradebook == Convert.ToInt32(rows.greadebook.text))
                        {
                            del = tmp;
                        }
                    }

                    setUsrList.Remove(del);
                    setUsrList.Add(us);
                    break;
                }
            
        }
            
        rows.greadebook.text = greadebook.text;
        rows.name.text = name.text;
        ButtonClass.exchange(rootPanel, readPanel);
        }
    }

    public void ButtonSend() {
        uc.deleteUsers(delUsrList);
        uc.updateUsers(updUsrList);
        uc.setUsers(setUsrList);
        usrList = null;
        setUsrList = null;
        updUsrList = null;
        delUsrList = null;
        foreach (GameObject o in objList)
            Destroy(o);
        objList = null;
    }
    public void ButtonGet() {
        if (objList != null)
        {
            foreach (GameObject o in objList)
                Destroy(o);
        }
         setUsrList=new List<User>();
         updUsrList=new List<User>();
         delUsrList = new List<User>();
         objList = new List<GameObject>();
         usrList=uc.getUsers();
         if (usrList == null) {
             return;
         }
         foreach (User usr in usrList) {
             GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsUser")));
             rowsUser script = rows.GetComponent<rowsUser>();
             script.greadebook.text =""+ usr.gradebook;
             script.name.text = usr.name;
             script.type.text = ""+(int)EnumType.REAL;
             rows.transform.parent = Content.transform;
             objList.Add(rows);
         }
    }

    private void writeField(User usr, int type) {
        description.text = usr.description;
        login.text = usr.login;
        password.text = usr.password;
        switch (usr.role) { 
            case "ADMIN":
                role.text = "Администратор";
                break;
            case "HEAD":
                role.text = "Управлящий";
                break;
            case "GIDES":
                role.text = "Гид";
                break;
            case "PORTER":
                role.text = "Встречающий";
                break;
        }
//        role.text = usr.role;
        this.type.text =""+ type;
    }

    public void DeleteRows(rowsUser rows)
    {
        switch(Convert.ToInt32(rows.type.text))
        {
            case (int)EnumType.REAL:
                {
                    User del = null;
                    foreach (User tmp in usrList)
                    {
                        if (tmp.gradebook == Convert.ToInt32(rows.greadebook.text))
                        {
                            del = tmp;

                        }
                    }
                    usrList.Remove(del);
                    delUsrList.Add(del);
                    break;
                }
            case (int)EnumType.READ:
                {
                    User del = null;
                    foreach (User tmp in updUsrList)
                    {
                        if (tmp.gradebook == Convert.ToInt32(rows.greadebook.text))
                        {
                            del = tmp;

                        }
                    }
                    updUsrList.Remove(del);
                    delUsrList.Add(del);
                    break;
                }
        }
        objList.Remove(rows.thisRows);
        Destroy(rows.thisRows);
    }

    public void ButtonAdd()
    {

        GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsUser")));
        rows.transform.parent=Content.transform;
        objList.Add(rows);
    }

}
