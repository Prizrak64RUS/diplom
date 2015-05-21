using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityEngine.UI;

public class infoPanel : MonoBehaviour {
    //стандартные
    public Text name;
    public Text description;
    public Button activ;
    public Button deActiv;

    //для групп
    public InputField nameG;
    public InputField descriptionG;

    public Button activPorter;

    public RectTransform rootPanel;
    public RectTransform thisPanel;

    public void ButtonPanelActiv() 
    {
        mapController.CallActivFieldChanged();
        Assets.myScript.button.ButtonClass.exchange(thisPanel, rootPanel);
    }

	// Use this for initialization
	void Start () 
    {
        EventSelectedPoint += SelectedPoint;
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
        deActiv.gameObject.SetActive(false);
        activ.gameObject.SetActive(false);
        switch (point.type) 
        {
            case PointType.ACTION:
                {
                    if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && !Data.getDataClass().isBusy) activ.gameObject.SetActive(true);
                    else activ.gameObject.SetActive(false);
                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            case PointType.NOT_ACTION:
                {
                    activ.gameObject.SetActive(false);
                    if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && Data.getDataClass().getBusy().idPoint == point.id)
                        deActiv.gameObject.SetActive(true);
                    
                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            case PointType.INFO:
                {
                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            case PointType.GROUP: 
                {
                    break;
                }
            case PointType.PORTER_POSITION:
                {
                    name.text = "Позиция встречающего";
                    description.text = "";
                    break;
                }
        }
    }
}
