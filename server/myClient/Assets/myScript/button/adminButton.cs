using UnityEngine;
using System.Collections;
using Assets.myScript.button;

public class adminButton : MonoBehaviour {
    public RectTransform adminPanel;
    public RectTransform userTablePanel;
    public RectTransform eventTablePanel;
    public RectTransform mapsPanel;

    public void ButtonAdminAndUser()
    {
        ButtonClass.exchange(adminPanel, userTablePanel);
    }

    public void ButtonAdminAndEvent()
    {
        ButtonClass.exchange(adminPanel, eventTablePanel);
    }

    public void ButtonAdminAndMaps()
    {
        ButtonClass.exchange(adminPanel, mapsPanel);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
