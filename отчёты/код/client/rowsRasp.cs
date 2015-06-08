using UnityEngine;
using System.Collections;
using Assets.myScript.entity;

public class rowsRasp : MonoBehaviour {

    public UnityEngine.UI.InputField date;
    public UnityEngine.UI.InputField time_start;
    public UnityEngine.UI.InputField time_end;
    public UnityEngine.UI.Text mc;
    public rowsRasp thisRows;
    public Schedulepoint sh;
    public void ButtonDell()
    {
        rootRaspClass.CallDeleteChanged(thisRows);
    }

    public void setMC(Schedulepoint sh) 
    {
        this.sh = sh;
        date.text = sh.date_start;
        time_start.text=sh.time_start;
        time_end.text=sh.time_end;
        foreach(var val in DataReader.GetDataReader().getMasterclassArr())
        {
            if(val.id==sh.id_masterclass){
                mc.text=val.name;
            }
        }
    }
}
