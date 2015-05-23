using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityEngine.UI;
using Assets.myScript.interfaceUrl;

public class infoPanel : MonoBehaviour {
    //стандартные
    public Text name;
    public Text description;
    public Button activ;
    public Button deActiv;

    public Button save;

    public Button breakB;
    //для групп
    public InputField nameG;
    public InputField descriptionG;

    Point thisPoint;

    public Button groupGet;

    public RectTransform rootPanel;
    public RectTransform thisPanel;

    public void ButtonActiv()
    {
        var data = Data.getDataClass();

        BusyController bc = new BusyController();
        PointController pc = new PointController();
        
        if (pc.busyPoint(new Point(thisPoint.id,data.user.id,1, thisPoint.name, thisPoint.type, thisPoint.description)))
        {
            var b = new Busy(data.user.id, thisPoint.id, data.getEventThis().id);
            bc.setBusy(b);

            ButtonPanelActiv();
        }
        else { description.text = "Ошибка, возможно позицию уже заняли"; }
        
    }

    public void ButtonDeActiv() 
    {
        var data = Data.getDataClass();

        BusyController bc = new BusyController();
        PointController pc = new PointController();

        if (pc.busyNotPoint(new Point(thisPoint.id, data.user.id, 0, thisPoint.name, thisPoint.type, thisPoint.description)))
        {
            var b = new Busy(data.user.id, thisPoint.id, data.getEventThis().id);
            bc.delBusy(b);

            ButtonPanelActiv();
        }
        else { description.text = "Ошибка, сервер не смог обработать команду, повторите действие"; }
    }

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
        thisPoint = point;

        ButtonPanelActiv();

        breakB.gameObject.SetActive(true);

        deActiv.gameObject.SetActive(false);
        activ.gameObject.SetActive(false);

        name.gameObject.SetActive(false);
        description.gameObject.SetActive(false);

        nameG.gameObject.SetActive(false);
        descriptionG.gameObject.SetActive(false);
        save.gameObject.SetActive(false);
        groupGet.gameObject.SetActive(false);
        //activPorter.gameObject.SetActive(false);
        switch (point.type) 
        {
            case PointType.ACTION:
                {
                    name.gameObject.SetActive(true);
                    description.gameObject.SetActive(true);
                    if (point.busy == 1)
                    {
                        if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && Data.getDataClass().getBusy().idPoint == point.id)
                            deActiv.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && Data.getDataClass().getBusy().idPoint == 0)
                            activ.gameObject.SetActive(true);
                    }
                    //name.gameObject.SetActive(true);
                    //description.gameObject.SetActive(true);

                    //if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && !Data.getDataClass().isBusy) 
                    //    activ.gameObject.SetActive(true);
                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            //case PointType.NOT_ACTION:
            //    {
            //        name.gameObject.SetActive(true);
            //        description.gameObject.SetActive(true);

            //        activ.gameObject.SetActive(false);
            //        if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) && Data.getDataClass().getBusy().idPoint == point.id)
            //            deActiv.gameObject.SetActive(true);
                    
            //        name.text = point.name;
            //        description.text = point.description;
            //        break;
            //    }
            case PointType.INFO:
                {
                    name.gameObject.SetActive(true);
                    description.gameObject.SetActive(true);

                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            case PointType.GROUP: 
                {
                    switch (Data.getDataClass().user.role)
                    {
                        case UserRole.GUIDES: 
                            {
                                name.gameObject.SetActive(true);
                                description.gameObject.SetActive(true);
                                name.text = point.name;
                                description.text = point.description;
                                groupGet.gameObject.SetActive(true);
                                break; 
                            }
                        case UserRole.HEAD: 
                            { 
                                name.gameObject.SetActive(true);
                                description.gameObject.SetActive(true);
                                name.text = point.name;
                                description.text = point.description;
                                break; 
                            }
                        case UserRole.PORTER: 
                            {
                                nameG.gameObject.SetActive(true);
                                descriptionG.gameObject.SetActive(true);
                                save.gameObject.SetActive(true);
                                nameG.text = point.name;
                                descriptionG.text = point.description;
                                breakB.gameObject.SetActive(false);
                                break; 
                            }
                    }
                    break;
                }
            case PointType.PORTER_POSITION:
                {
                    name.gameObject.SetActive(true);
                    description.gameObject.SetActive(true);

                    if (point.busy==1)
                    {
                        if (Data.getDataClass().user.role.Equals(UserRole.PORTER) && Data.getDataClass().getBusy().idPoint == point.id)
                            deActiv.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (Data.getDataClass().user.role.Equals(UserRole.PORTER) && Data.getDataClass().getBusy().idPoint==0)
                            activ.gameObject.SetActive(true);
                    }
                    name.text = "Позиция встречающего";
                    description.text = "";
                    break;
                }
        }
    }

    public void ButtonSave() 
    {
        if (nameG.text.Equals("") || descriptionG.text.Equals("")) return;
        thisPoint.name = nameG.text;
        thisPoint.description = descriptionG.text;
        thisPoint.id_user_Busy = Data.getDataClass().user.id;
        ButtonPanelActiv();
    }

    public void ButtonGroupGet() 
    {
        var data = Data.getDataClass();

        BusyController bc = new BusyController();
        PointController pc = new PointController();

        if (pc.busyPoint(new Point(thisPoint.id, data.user.id, 1, thisPoint.name, thisPoint.type, thisPoint.description)))
        {
            pc.delBusyPoint(new Point(thisPoint.id, data.user.id, 1, thisPoint.name, thisPoint.type, thisPoint.description));

            ButtonPanelActiv();
        }
        else { description.text = "Ошибка, возможно позицию уже заняли"; }
    }
}
