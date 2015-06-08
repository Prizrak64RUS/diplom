using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class buttonSelectedMap : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public Maps map;

    public Assets.myScript.entity.Event ev;
    public Masterclass mc;

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

    public void ButtonSelectedMapOkInProgram()
    {
        mapController.CallActivFieldChanged();
        panelSelectedMap.CallMapNameSelectedChanged(false);
        mapController.CallMapBuildChanged(map);
    }

    public void ButtonSelectedUser()
    {
        panelChat.CallUserSelectedChanged(text.text);
        panelSelectedMap.CallMapNameSelectedChanged(false);
    }

    public void ButtonSelectedEvent()
    {
        //panelChat.CallUserSelectedChanged(text.text);
        generator.CallOkSelectedChanged(ev);
        panelSelectedMap.CallMapNameSelectedChanged(false);
    }

    public void ButtonSelectedEvent1()
    {
        rootMCClass.CallSetEvChanged(ev.id);
        adminButton.CallAdminAndMCChanged();
        panelSelectedMap.CallMapNameSelectedChanged(false);
    }

    public void ButtonSelectedEvent2()
    {
        DataReader.GetDataReader().thisEv = ev;
        Application.LoadLevel("pointReader");
    }
    //public void ButtonSelectedPanel()
    //{
    //    textSelectedView = text;
    //    panelSelectedEvent.CallmapTypeEventSelectedChanged(true);
    //}
}
