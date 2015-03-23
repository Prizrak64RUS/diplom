using UnityEngine;
using System.Collections;
using Assets.myScript.button;
using Assets.myScript;
using Assets.myScript.interfaceUrl;
public class RootMenuButton : MonoBehaviour {

    public RectTransform StartPanel;
    public RectTransform ConnectTypePanel;
    public RectTransform AddressPanel;
    public RectTransform AuthPanel;

    public UnityEngine.UI.Text errorIp;


    public void ButtonStartAndConnectType()
    {
        ButtonClass.exchange(StartPanel, ConnectTypePanel);
    }

    public void ButtonConnectTypeAndAddress()
    {
        ButtonClass.exchange(AddressPanel, ConnectTypePanel);
    }


    public void ButtonConnectToIp() {
        if (!Data.getDataClass().url.Equals("") && TestController.testConnect())
        {
            ButtonAuthAndAddress();
        }
        else { 
            if(errorIp.text.Equals("")) 
            errorIp.text = "Сервер недоступен"; 
        }
    }

    public void ButtonAuthAndAddress()
    {
        ButtonClass.exchange(AddressPanel, AuthPanel);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }


}
