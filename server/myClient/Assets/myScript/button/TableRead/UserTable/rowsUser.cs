﻿using UnityEngine;
using System.Collections;

public class rowsUser : MonoBehaviour {

    public UnityEngine.UI.InputField greadebook;
    public UnityEngine.UI.InputField name;
    public UnityEngine.UI.Text type;
    public GameObject thisRows;

    public void ButtonRead() {
        rootUserClass.CallUserReadChanged(this);
    }

    public void ButtonDell()
    {
        rootUserClass.CallUserDeleteChanged(this);
    }
}
