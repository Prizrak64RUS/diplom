using UnityEngine;
using System.Collections;

public class panelSelectedEvent : MonoBehaviour {


    public delegate void mapTypeEventSelectedDelegate(bool val);
    public static event mapTypeEventSelectedDelegate EventMapTypeEventSelected;
    public static void CallmapTypeEventSelectedChanged(bool val)
    {
        var handler = EventMapTypeEventSelected;
        if (EventMapTypeEventSelected != null) // если есть подписчики
        {
            EventMapTypeEventSelected(val);
        }
    }
    void Start() {
        EventMapTypeEventSelected += SelectedPanel;
    }
    public void SelectedPanel(bool val) {
        this.gameObject.SetActive(val);
    }
}
