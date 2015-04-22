using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class rowsEvent : MonoBehaviour {

    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.InputField date;
    public UnityEngine.UI.Toggle isActiv;
    public UnityEngine.UI.InputField name;
    public Assets.myScript.entity.Event events;
    public GameObject thisRows;

    public void ButtonDell()
    {
        rootEventClass.CallEventDeleteChanged(this);
    }

    public void ButtonSelected()
    {
        rootEventClass.CallEventSelectedChanged(this);
    }
}
