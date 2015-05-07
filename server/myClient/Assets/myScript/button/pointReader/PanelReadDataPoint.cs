using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.myScript.entity;

public class PanelReadDataPoint : MonoBehaviour {

    public InputField name;
    public InputField description;
    public Toggle isActiv;
    public Toggle isNext;
    public Toggle isInfo;

    public void SelectedToggle(string type) {
        switch (type) 
        {
            case "ACTIV":
                if (isActiv.isOn)
                {
                    isNext.isOn = false;
                    isInfo.isOn = false;
                }
                break;
            case "NEXT":
                if (isNext.isOn)
                {
                    isActiv.isOn = false;
                    isInfo.isOn = false;
                }
                break;
            case "INFO":
                if (isInfo.isOn)
                {
                    isNext.isOn = false;
                    isActiv.isOn = false;
                }
                break;
        }
    }

    public Point getPoint() {
        string type="";
        if (isActiv.isOn)
            type = "ACTIV";
        if (isNext.isOn)
            type = "NEXT";
        if (isInfo.isOn)
            type = "INFO";
        if (name.text.Equals("") || type.Equals("") || description.text.Equals(""))
            return null;

        return new Point(name.text, type, description.text);


    }
    public void setPoint(Point p)
    {
        name.text = p.name;
        description.text = p.description;
        if (p.type != "")
        {
            switch (p.type)
            {
                case "ACTIV":
                    isActiv.isOn = true;
                    break;
                case "NEXT":
                    isNext.isOn = true;
                    break;
                case "INFO":
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
