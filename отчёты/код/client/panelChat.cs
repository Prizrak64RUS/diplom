using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.myScript.interfaceUrl;
using UnityEngine.UI;
using Assets.myScript.entity;
using System;

public class panelChat : MonoBehaviour {

    public delegate void UserSelectedDelegate(string val);
    public static event UserSelectedDelegate EventUserSelected;
    public static void CallUserSelectedChanged(string val)
    {
        var handler = EventUserSelected;
        if (EventUserSelected != null) // если есть подписчики
        {
            EventUserSelected(val);
        }
    }

    public GameObject Content;

    List<GameObject> objList;
    MessageController mc;
    public InputField textAdd;
    public Text whereAdd;
    public Button add;

    Int32[] val;
	// Use this for initialization
	void Start () {
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING)) { return; }
        objList = new List<GameObject>();
        mc = new MessageController();
        val = new Int32[4];
        val[0] = 0;
        val[1] = Data.getDataClass().getEventThis().id;
        val[2] = Data.getDataClass().user.id;

        EventUserSelected += SetUser;

        List<Message> list=null;
        while (list == null)
            list = mc.getEndSevenMessage(val);

        foreach (var el in list)
            addInContent(el);

        StartCoroutine("AutoMessageGet");
	}

    void SetUser(string val) {
        whereAdd.text = val;
    }

    void addInContent(Message mes) 
    {
        GameObject obj = (GameObject)Instantiate(Resources.Load(("rowsChat")));
        rowsChat script = obj.GetComponent<rowsChat>();
        script.SetMessage(mes);
        obj.transform.parent = Content.transform;
        val[0] = mes.id;

        objList.Add(obj);
    }

    public void ButtonAddText() 
    {
        if (textAdd.text.Equals("")) return;
        int where = 0;
        if (!whereAdd.text.Equals("Всем")) 
        {
            var list = Data.getDataClass().getUsers();
            foreach (var usr in list) 
            {
                if (usr.name.Equals(whereAdd.text)) 
                {
                    where = usr.id;
                }
            }
        }
        var mes = new Message(textAdd.text, Data.getDataClass().user.id, where ,"-", Data.getDataClass().getEventThis().id);
        var contr = new MessageController();
        contr.setChatMessage(mes);
        textAdd.text = "";
        whereAdd.text = "Всем";
    }

    private IEnumerator AutoMessageGet()
    {
        while (true)
        {
            var list = mc.getChatOf(val);
            if (list == null) yield return new WaitForSeconds(2);
            foreach (var el in list)
            {
                addInContent(el);
            }
            ClearChat();
            yield return new WaitForSeconds(10);
        }
    }

    void ClearChat() 
    {
        if (objList.Count > 25) 
        {
            int val = objList.Count - 25;
            var arr = objList.ToArray();
            for (int i = 0; i <= val; i++) 
            {
                objList.Remove(arr[i]);
                Destroy(arr[i]);
            }
        }
    }

}
