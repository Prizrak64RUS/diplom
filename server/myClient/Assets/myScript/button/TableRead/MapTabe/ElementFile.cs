using UnityEngine;
using System.Collections;

public class ElementFile : MonoBehaviour {

    public bool isFile;

    public void ButtonAction() 
    {
        if (isFile)
        {
            SearchFile.CallMapFileOkChanged(this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text);
        }
        else
        {
            SearchFile.CallMapFileNextChanged(this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text);
        }
    }
}
