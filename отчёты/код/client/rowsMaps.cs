using UnityEngine;
using System.Collections;

public class rowsMaps : MonoBehaviour {

    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.Text type;
    public UnityEngine.UI.InputField name;
    public Assets.myScript.entity.Maps map;
    public GameObject thisR;

	// Use this for initialization

    public void ButtonDelete() {
        MapsRoot.CallMapsDeleteChanged(this);
    }
}
