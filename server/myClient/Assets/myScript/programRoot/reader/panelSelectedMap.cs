using UnityEngine;
using System.Collections;

public class panelSelectedMap : MonoBehaviour {

    //public static UnityEngine.UI.Text textSelectedView;

    public delegate void mapNameSelectedDelegate(bool val);
    public static event mapNameSelectedDelegate EventMapmapNameSelected;
    public static void CallMapNameSelectedChanged(bool val)
    {
        var handler = EventMapmapNameSelected;
        if (EventMapmapNameSelected != null) // если есть подписчики
        {
            EventMapmapNameSelected(val);
        }
    }
    void Start()
    {
        this.gameObject.SetActive(false);
        EventMapmapNameSelected += SelectedPanel;
    }
    public void SelectedPanel(bool val)
    {
        this.gameObject.SetActive(val);
    }
}
