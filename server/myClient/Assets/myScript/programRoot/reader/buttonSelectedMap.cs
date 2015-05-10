using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class buttonSelectedMap : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public Maps map;

    public void ButtonUnSelectedPanel()
    {
        panelSelectedMap.CallMapNameSelectedChanged(false);
        mapWriter.CallMapBuildChanged(null, map);
    }

    public void ButtonDataReadOk()
    {
        panelSelectedMap.CallMapNameSelectedChanged(false);
        PanelReadDataPoint.CallMapSelect(map);
    }


    //public void ButtonSelectedPanel()
    //{
    //    textSelectedView = text;
    //    panelSelectedEvent.CallmapTypeEventSelectedChanged(true);
    //}
}
