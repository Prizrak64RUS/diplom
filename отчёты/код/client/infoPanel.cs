using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityEngine.UI;
using Assets.myScript.interfaceUrl;
using System;
using System.Collections.Generic;

public class infoPanel : MonoBehaviour {
    //стандартные
    public Text name;
    public Text description;
    public Button activ;
    public Button deActiv;

    public Button rasp;

    public Button save;

    public Button breakB;
    //для групп
    public GameObject Scrol;

    public GameObject ScrolRasp;
    public GameObject ContentRasp;

    public InputField numberСhild;
    public InputField numberResponsible;
    public InputField responsible;
    public InputField school;
    public InputField location;

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
        ScrolRasp.SetActive(false);
        rasp.gameObject.SetActive(false);

        name.gameObject.SetActive(false);
        description.gameObject.SetActive(false);

        Scrol.SetActive(false);
        save.gameObject.SetActive(false);
        groupGet.gameObject.SetActive(false);
        //activPorter.gameObject.SetActive(false);
        name.text = "";
        description.text = "";
        switch (point.type)
        {
            case PointType.ACTION:
                {
                    if (!Data.getDataClass().user.role.Equals(UserRole.WATCHING))
                    {
                        rasp.gameObject.SetActive(true);
                    }
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
                    SchedulepointController sh = new SchedulepointController();
                    Schedulepoint sho = sh.getSchedulepointOneFromTime(thisPoint.id);
                    var mcList = Data.getDataClass().getMC();
                    if (sho == null) { name.text = "Масте-класс не идёт"; }
                    else 
                    {
                        foreach (var m in mcList) 
                        {
                            if (m.id == sho.id_masterclass) 
                            {
                                name.text = m.name;
                                description.text = sho.time_start + " - " + sho.time_end + "\n" + m.decription + ".\nВедёт: " + m.lecturer1;
                            }
                        }
                    }
                    break;
                }
            case PointType.INFO:
                {
                    name.gameObject.SetActive(true);
                    description.gameObject.SetActive(true);

                    name.text = point.name;
                    description.text = point.description;
                    break;
                }
            case PointType.PORTER_POSITION:
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
                    name.text = "Позиция встречающего";
                    description.text = "";
                    break;
                }
            case PointType.NOT_ACTION:
                {
                    school.text = "";
                    responsible.text = "";
                    location.text = "";
                    numberСhild.text = "";
                    numberResponsible.text = "";

                    Scrol.SetActive(true);
                    save.gameObject.SetActive(true);
                    break;
                }
        }
    }

    public void ButtonSave() 
    {
        if (school.text.Equals("")
            || responsible.text.Equals("") || location.text.Equals("") || numberСhild.text.Equals("")
            || numberResponsible.text.Equals("")) return;

        var Сhild = Int32.Parse(numberСhild.text);
        var Responsible =Int32.Parse(numberResponsible.text);
        var g = new Group(Data.getDataClass().getEventThis().id, Сhild, Responsible, Сhild + Responsible, responsible.text, school.text, location.text, "", 1);
        var gc = new GroupController();
        int sv = gc.setGroup(g);
        if (sv != 0)
        {
            new BusyController().setBusy(new Busy(Data.getDataClass().user.id, 0, sv));
        }
        Debug.Log(sv);
        school.text = "";
        responsible.text = "";
        location.text = "";
        numberСhild.text = "";
        numberResponsible.text = "";
        //while (!gc.setGroup(g)) { }
        ButtonPanelActiv();
    }

    List<GameObject> objList = new List<GameObject>();
    public void ButtonRasp()
    {
        foreach (var o in objList)
            Destroy(o);
        objList.Clear();
        breakB.gameObject.SetActive(true);

        deActiv.gameObject.SetActive(false);
        activ.gameObject.SetActive(false);
        rasp.gameObject.SetActive(false);
        name.gameObject.SetActive(false);
        description.gameObject.SetActive(false);

        Scrol.SetActive(false);
        save.gameObject.SetActive(false);
        groupGet.gameObject.SetActive(false);

        ScrolRasp.SetActive(true);


        SchedulepointController sh = new SchedulepointController();
        List<Schedulepoint> shList = sh.getSchedulepointFromTime(thisPoint.id);
        var mcList = Data.getDataClass().getMC();
        if (shList.Count == 0) 
        {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsRaspWriteN")));
            rowsRaspWrite script = rows.GetComponent<rowsRaspWrite>();
            script.t_start.text = "Для данной точки все события на сегодня закончились";
            rows.transform.parent = ContentRasp.transform;
            objList.Add(rows);
        }
        foreach (var objsh in shList) 
        {
            GameObject rows = (GameObject)Instantiate(Resources.Load(("rowsRaspWrite")));
            rowsRaspWrite script = rows.GetComponent<rowsRaspWrite>();
            script.t_start.text = objsh.time_start;
            script.t_end.text = objsh.time_end;
            foreach (var objmc in mcList)
            {
                if (objmc.id == objsh.id_masterclass)
                {
                    script.lec.text = objmc.lecturer1;
                    script.name.text = objmc.name;
                    break;
                }
            }


            rows.transform.parent = ContentRasp.transform;
            objList.Add(rows);
        }
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
