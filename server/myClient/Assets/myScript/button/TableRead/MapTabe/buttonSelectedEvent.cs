using UnityEngine;
using System.Collections;

public class buttonSelectedEvent : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public static UnityEngine.UI.Text textSelectedView; 

    public void ButtonUnSelectedPanel()
    {
        panelSelectedEvent.CallmapTypeEventSelectedChanged(false);
    }

    public void ButtonSelectedPanel()
    {
        textSelectedView = text;
        panelSelectedEvent.CallmapTypeEventSelectedChanged(true);
    }



    public void ButtonSetName()
    {
        textSelectedView.text = text.text;
    }
}
