using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.myScript.entity;
using Assets.myScript.interfaceUrl;

public class PanelReadDataPoint : MonoBehaviour {

    public GameObject nameObj;
    public InputField name;
    public GameObject descriptionObj;
    public InputField description;
    public GameObject numberObj;
    public InputField number;
    public Toggle isActiv;
    public Toggle isNext;
    public Toggle isInfo;
    public Button addRasp;
    public Button map;
    public Text mapText;
    int id;
    int id_user_Busy;
    Maps mapsObj;

    public rootRaspClass rrc;

    public RectTransform addRaspPanel;

    public void ButtonThisAndAddRaspPanel()
    {
            ButtonSetIdPoint();
            var trans = gameObject.transform.localPosition;
            gameObject.transform.localPosition = addRaspPanel.transform.localPosition;
            addRaspPanel.transform.localPosition = trans;
    }

    public void ButtonSetIdPoint()
    {
        rrc.idPoint = id;
    }

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
                    nameObj.SetActive(false);
                    numberObj.SetActive(true);
                    descriptionObj.SetActive(false);
                    addRasp.gameObject.SetActive(true);
                    map.gameObject.SetActive(false);
                    isNext.isOn = false;
                    isInfo.isOn = false;
                }
                break;
            case PointType.NEXT:
                if (isNext.isOn)
                {
                    nameObj.SetActive(false);
                    numberObj.SetActive(false);
                    descriptionObj.SetActive(false);
                    addRasp.gameObject.SetActive(false);
                    isActiv.isOn = false;
                    isInfo.isOn = false;
                    map.gameObject.SetActive(true);
                }
                break;
            case PointType.INFO:
                if (isInfo.isOn)
                {
                    nameObj.SetActive(true);
                    numberObj.SetActive(false);
                    descriptionObj.SetActive(true);
                    addRasp.gameObject.SetActive(false);
                    map.gameObject.SetActive(false);
                    isNext.isOn = false;
                    isActiv.isOn = false;
                }
                break;
        }
    }

    public Point getPoint() {
        string type="";
        Point p=null;
        if (isActiv.isOn)
        {
            type = PointType.ACTION;
            if (number.Equals("") || type.Equals(""))
                return null;
            p= new Point(name.text, type, "", id, 0, System.Int32.Parse(number.text));
        }
        if (isNext.isOn)
        {
            type = PointType.NEXT;
            if (type.Equals("") || mapText.text.Equals("NONE"))
                return null;
            p= new Point("", type, "", id, id_user_Busy, 0);
        }
        if (isInfo.isOn)
        {
            type = PointType.INFO;
            if (name.text.Equals("") || type.Equals("") || description.text.Equals(""))
                return null;
            p= new Point(name.text, type, description.text, id, 0, 0);
        }
        
        //if (name.text.Equals("") || type.Equals("") || description.text.Equals(""))
            return p;
        //return new Point(name.text, type, description.text, id, id_user_Busy,System.Int32.Parse(number.text));


    }
    public void setPoint(Point p)
    {
        name.text = p.name;
        id = p.id;
        mapText.text = "NONE";
        id_user_Busy = p.id_user_Busy;
        description.text = p.description;
        if(p.all_space==0){number.text ="";}
        else 
            number.text =""+p.all_space;
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
