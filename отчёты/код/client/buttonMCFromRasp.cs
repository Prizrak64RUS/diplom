using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonMCFromRasp : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public static UnityEngine.UI.Text textSelectedView;

    public void ButtonUnSelectedPanel()
    {
        panelSelectedMap.CallMapNameSelectedChanged2(false);
    }

    public void ButtonSelectedPanel()
    {
        textSelectedView = text;
        panelSelectedMap.CallMapNameSelectedChanged2(true);
    }



    public void ButtonSetName()
    {
        textSelectedView.text = text.text;
    }
}
