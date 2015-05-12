using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityEngine.UI;

public class infoPanel : MonoBehaviour {

    public Text name;
    public Text description;
    public Button activ;

    public RectTransform rootPanel;
    public RectTransform thisPanel;

    public void ButtonPanelActiv() 
    {
        mapController.CallActivFieldChanged();
        Assets.myScript.button.ButtonClass.exchange(thisPanel, rootPanel);
    }

	// Use this for initialization
	void Start () {
        EventSelectedPoint += SelectedPoint;
        switch (Data.getDataClass().user.role) 
        {
            case UserRole.HEAD:
            case UserRole.PORTER:
            case UserRole.WATCHING:
                activ.gameObject.SetActive(false);
                break;
        }
	}


    public delegate void selectedPointDelegate(Point point);
    public static event selectedPointDelegate EventSelectedPoint;
    public static void CallSelectedPointChanged(Point point)
    {
        var handler = EventSelectedPoint;
        if (EventSelectedPoint != null) // если есть подписчики
        {
            EventSelectedPoint(point);
        }
    }


    void SelectedPoint(Point point)
    {
        ButtonPanelActiv();
        if (Data.getDataClass().user.role.Equals(UserRole.GUIDES)&&!Data.getDataClass().isBusy)
            activ.gameObject.SetActive(true);
        else
            activ.gameObject.SetActive(false);

        if (point.type.Equals(PointType.INFO))
            activ.gameObject.SetActive(false);
        name.text = point.name;
        description.text = point.description;
    }
}
