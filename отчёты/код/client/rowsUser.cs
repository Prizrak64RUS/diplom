using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class rowsUser : MonoBehaviour {

    public UnityEngine.UI.InputField greadebook;
    public UnityEngine.UI.InputField name;
    public GameObject thisRows;
    public User user;

    public void ButtonRead() {
        rootUserClass.CallUserReadChanged(this);
    }

    public void ButtonDell()
    {
        rootUserClass.CallUserDeleteChanged(this);
    }
}
