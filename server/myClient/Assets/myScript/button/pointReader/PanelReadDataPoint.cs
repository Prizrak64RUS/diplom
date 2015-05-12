using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;

public class PanelReadDataPoint : MonoBehaviour {

    public InputField name;
    public InputField description;
    public Toggle isActiv;
    public Toggle isNext;
    public Toggle isInfo;
    public Button map;
    public Text mapText;
    int id;
    int id_user_Busy;
    Maps mapsObj;

    void Start() 
    {
        EventMapSelect += addMap;
    }

    void addMap(Maps mapsObj) {
        id_user_Busy = mapsObj.id;
        mapText.text = mapsObj.name;
    }

    public delegate void mapSelectDelegate(Maps map);
    public static event mapSelectDelegate EventMapSelect;
    public static void CallMapSelect(Maps map)
    {
        var handler = EventMapSelect;
        if (EventMapSelect != null) // если есть подписчики
        {
            EventMapSelect(map);
        }
    }

    public void SelectedToggle(string type) {
        switch (type) 
        {
            case PointType.ACTION:
                if (isActiv.isOn)
                {
                    map.gameObject.SetActive(false);
                    isNext.isOn = false;
                    isInfo.isOn = false;
                }
                break;
            case PointType.NEXT:
                map.gameObject.SetActive(false);
                if (isNext.isOn)
                {
                    isActiv.isOn = false;
                    isInfo.isOn = false;
                    map.gameObject.SetActive(true);
                }
                break;
            case PointType.INFO:
                if (isInfo.isOn)
                {
                    map.gameObject.SetActive(false);
                    isNext.isOn = false;
                    isActiv.isOn = false;
                }
                break;
        }
    }

    public Point getPoint() {
        string type="";
        if (isActiv.isOn)
            type = PointType.ACTION;
        if (isNext.isOn)
            type =PointType.NEXT;
        if (isInfo.isOn)
            type = PointType.INFO;
        if (isNext.isOn && mapText.text.Equals("NONE")) return null;
        if (name.text.Equals("") || type.Equals("") || description.text.Equals(""))
            return null;
        return new Point(name.text, type, description.text, id, id_user_Busy);


    }
    public void setPoint(Point p)
    {
        name.text = p.name;
        id = p.id;
        mapText.text = "NONE";
        id_user_Busy = p.id_user_Busy;
        description.text = p.description;
        if (p.type != "")
        {
            switch (p.type)
            {
                case PointType.ACTION:
                    isActiv.isOn = true;
                    break;
                case PointType.NEXT:
                    isNext.isOn = true;
                    MapsController mc = new MapsController();
                    mapText.text = mc.getMap(id_user_Busy).name;
                    break;
                case PointType.INFO:
                    isInfo.isOn = true;
                    break;
            }
        }
        else 
        {
            isInfo.isOn = false;
            isNext.isOn = false;
            isActiv.isOn = false;
        }
    }
}
