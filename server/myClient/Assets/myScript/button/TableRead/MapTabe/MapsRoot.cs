using UnityEngine;
using System.Collections;
using Assets.myScript.button;

public class MapsRoot : MonoBehaviour {

    public RectTransform mapsTablePanel;
    public RectTransform mapsPanel;

    public void ButtonMapsRead()
    {
        ButtonClass.exchange(mapsPanel, mapsTablePanel);
    }

    public void ButtonPointRead()
    {
        Application.LoadLevel("pointReader");
    }
}
