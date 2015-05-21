using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityEngine.UI;

public class rowsChat : MonoBehaviour {

    public Text date;
    public Text info;
    public Text userSend;


    public void SetMessage(Message mes)
    {
        info.text = mes.message;
        date.text = mes.date;
        var list = Data.getDataClass().getUsers();
        if (mes.idUserTo != 0)
        {
            foreach (var us in list)
            {
                if (us.id == mes.idUser)
                {
                    userSend.text = us.name;
                    break;
                }
                else userSend.text = "NONE";
            }
            userSend.color = Color.red;
        }
        else userSend.text = "NONE";
        
    }
}
