using UnityEngine;
using System.Collections;

public class programButtomReaderSetting : MonoBehaviour {


    public GameObject buttonOldPanel;
    public GameObject buttonoMapSelected;
    public GameObject buttonOk;
    public GameObject buttonBreak;
    public GameObject buttonUpHorizontal;
    public GameObject buttonDownHorizontal;
    public GameObject buttonUpVertikal;
    public GameObject buttonDownVertikal;
	// Use this for initialization
	void Start () {
        EventButtonActiv += ButtonActivPoint;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonUpOrDown(int key)
    {
        bool isUp = false, isHorizontal = false;
        switch (key)
        {
            case 1:
                isUp = true;
                break;
            case 2:
                isHorizontal = true;
                break;
            case 3:
                isUp = true; isHorizontal = true;
                break;
            default:
                break;
        }
        mapController.CallUpOrDownSizePointMapChanged(isUp, isHorizontal);
    }

    public void ButtonOkOrCancel(bool isOk)
    {
        //DataReader.GetDataReader().isRead = false;
        mapController.CallOkOrCancelPointMapChanged(isOk);
    }


    public delegate void ButtonActivDelegate(bool val);
    public static event ButtonActivDelegate EventButtonActiv;
    public static void CallButtonActivChanged(bool val)
    {
        var handler = EventButtonActiv;
        if (EventButtonActiv != null) // если есть подписчики
        {
            EventButtonActiv(val);
        }
    }

    public void ButtonActivPoint(bool val)
    {
        buttonOldPanel.SetActive(!val);
        buttonoMapSelected.SetActive(!val);
        buttonOk.SetActive(val);
        if (!Data.getDataClass().user.role.Equals(UserRole.PORTER))
        {
            buttonBreak.SetActive(val);
        }
        buttonUpHorizontal.SetActive(val);
        buttonDownHorizontal.SetActive(val);
        buttonUpVertikal.SetActive(val);
        buttonDownVertikal.SetActive(val);
    }
}
