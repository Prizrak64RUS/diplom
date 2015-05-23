using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class generator : MonoBehaviour {

    public delegate void okSelectedDelegate(Assets.myScript.entity.Event ev);
    public static event okSelectedDelegate EventOkSelected;
    public static void CallOkSelectedChanged(Assets.myScript.entity.Event ev)
    {
        var handler = EventOkSelected;
        if (EventOkSelected != null) // если есть подписчики
        {
            EventOkSelected(ev);
        }
    }

    public void Exit() 
    {
        Application.Quit();
    }

    public void ButtonBreak()
    {
        exchange(selectedPanel, generatorPanel);
    }

    void Start() 
    {
        EventOkSelected += panelNext;
    }

    public RectTransform selectedPanel;
    public RectTransform generatorPanel;

    public Text name;

    Assets.myScript.entity.Event ev;

    void panelNext(Assets.myScript.entity.Event ev) 
    {
        exchange(selectedPanel, generatorPanel);
        this.ev = ev;
        name.text = ev.name;
    }

    public static void exchange(RectTransform x1, RectTransform x2)
    {
        var trans = x1.localPosition;
        x1.localPosition = x2.localPosition;
        x2.localPosition = trans;
    }
}
