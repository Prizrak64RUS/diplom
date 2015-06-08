using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class rowsMC : MonoBehaviour {

    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.InputField name;
    public UnityEngine.UI.InputField lec1;
    public UnityEngine.UI.InputField lec2;
    public UnityEngine.UI.InputField lec3;
    public rowsMC thisRows;
    public Masterclass mc;
    public void ButtonDell()
    {
        rootMCClass.CallDeleteChanged(thisRows);
    }

    public void setMC(Masterclass ms) 
    {
        this.mc = ms;
        description.text = ms.decription;
        name.text = ms.name;
        lec1.text = ms.lecturer1;
        lec2.text = ms.lecturer2;
        lec3.text = ms.lecturer3;
    }

    public Masterclass getMC()
    {
        return mc;
    }
}
