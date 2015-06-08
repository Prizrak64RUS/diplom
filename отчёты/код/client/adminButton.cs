using UnityEngine;
using System.Collections;
using Assets.myScript.button;

public class adminButton : MonoBehaviour {
    public RectTransform adminPanel;
    public RectTransform userTablePanel;
    public RectTransform eventTablePanel;
    public RectTransform mapsPanel;
    public RectTransform MCPanel;

    public delegate void AdminAndMCDelegate();
    public static event AdminAndMCDelegate EventAdminAndMC;
    public static void CallAdminAndMCChanged()
    {
        var handler = EventAdminAndMC;
        if (EventAdminAndMC != null) // если есть подписчики
        {
            EventAdminAndMC();
        }
    }

    void Start() 
    {
        EventAdminAndMC += ButtonAdminAndMC;
    }

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

    public void ButtonAdminAndMC()
    {
        ButtonClass.exchange(adminPanel, MCPanel);
    }


    public void ButtonExit()
    {
        Application.Quit();
    }
}
