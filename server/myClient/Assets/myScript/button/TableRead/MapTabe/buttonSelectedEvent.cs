using UnityEngine;
using System.Collections;

public class buttonSelectedEvent : MonoBehaviour {

    public void ButtonUnSelectedPanel()
    {
        panelSelectedEvent.CallmapTypeEventSelectedChanged(false);
    }

    public void ButtonSelectedPanel()
    {
        panelSelectedEvent.CallmapTypeEventSelectedChanged(true);
    }
    public void ButtonSetName()
    {
        rowsMaps.CallmapTypeEventSetNameChanged(this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text);
    }
}
