using UnityEngine;
using System.Collections;
using System;
using Assets.myScript;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;

public class OldButton : MonoBehaviour {

    public UnityEngine.UI.Text errorIp;
    public UnityEngine.UI.InputField ipAddress;

    public UnityEngine.UI.InputField login;
    public UnityEngine.UI.InputField password;
    public UnityEngine.UI.Text errorAuth;


    public void ButtonAuth() {
        User user = new User(login.text, password.text);
        UserController uc = new UserController();
        User autch=null;
        while (autch == null)
            autch = uc.isAutch(user);
        user = autch;
        if (!user.role.Equals("NONE")) 
        {
            Data.getDataClass().user = user;

            if (user.role.Equals("ADMIN"))
            {
                Application.LoadLevel("admin");
            }
            else
            {
                if (loadData())
                {
                    Application.LoadLevel("program");

                }
                else
                {
                    errorAuth.text = "Сервер в режиме ожидания";
                }
            }
        } else { errorAuth.text = "Неправильный логин или пароль"; }
    }

    private bool loadData() 
    {
        try
        { 
            var data = Data.getDataClass();
            var ec = new EventController();
            while (data.getEventThis() == null) { }
            while (data.getMaps() == null) { }
            data.selectedMap = data.getMaps().ToArray()[0];
            return true;
        }
        catch (Exception e) { return false; }
    }

    public void ButtonWATCHINGAuth()
    {
        if (loadData())
        {
            GroupController gc = new GroupController();
            gc.updGroup(new Group(Data.getDataClass().getEventThis().id));
            Application.LoadLevel("program");

        }
        else
        {
            errorAuth.text = "Сервер в режиме ожидания";
        }
    }
    
    public void ButtonAuthDataClear() {
        login.text="";
        password.text="";
        errorAuth.text = "";
    }
    
    public void ButtonGetIp(string s) {
        if (isCorrectIp(ipAddress.text)) {
            Data.getDataClass().url = "http://" + ipAddress.text + ":8080"; 
            errorIp.text = ""; 
        }
        else
        {
            Data.getDataClass().url = "";
            errorIp.text = "Не корректный ip";
        }
    }

    public void ButtonClearIp()
    {
        Data.getDataClass().url = "";
        ipAddress.text = "";
        errorIp.text = "";
    }

    bool isCorrectIp (string s) {
        char[] ch = new char[1];
        ch[0]='.';
        string[] sArr= s.Split(ch);
        try 
        {
            if (sArr.Length != 4) { throw new Exception(); }
            for (int i = 0; i < sArr.Length; i++) {
            
                int val= Int32.Parse(sArr[i]);
                if (val > 255 || val < 0) { throw new Exception(); }
            }
        }
        catch (Exception e) { return false; }
            return true;
    } 

}
