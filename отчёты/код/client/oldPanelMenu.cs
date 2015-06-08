using UnityEngine;
using System.Collections;
using Assets.myScript.button;
using UnityEngine.UI;
using Assets.myScript.interfaceUrl;
using Assets.myScript.entity;

public class oldPanelMenu : MonoBehaviour {


    public RectTransform rootMenu;
    public RectTransform oldMenu;
    public RectTransform newsPanel;
    public RectTransform chatPanel;

    public Button chat;
    public Button addP;

    public Button GroupGet;
    public Button GroupEnd;

   // public Button getPos;

    public Button generator;
    //public GameObject addPoint;
   public void ButtonEnd()
    {
        Application.Quit();
    }

   //public void ButtonGetPos()
   //{
   //    ButtonRootAndOld();
   //    var pc = new PointController();
   //    var p = pc.getPoint(Data.getDataClass().getBusy().idPoint);
   //    var map = new Maps(p.id_map);
   //    mapController.CallMapBuildChanged(map);
   //}

    public void ButtonGroupGet()
    {
        mapController.CallActivFieldChanged();
        ButtonClass.exchange(rootMenu, oldMenu);
        infoPanel.CallSelectedPointChanged(new Point(PointType.NOT_ACTION));
    }

    public void ButtonGroupEnd()
    {
        var id = Data.getDataClass().getBusy().idGroup;
        new GroupController().endGroup(id);
        new BusyController().delBusy(new Busy(0,0,id));
        GroupEnd.gameObject.SetActive(false);
    }

   public void ButtonGenerator()
   {
       Application.LoadLevel("generator");
   } 

    public void ButtonNewsPanel() {
        ButtonClass.exchange(newsPanel, oldMenu);
    }

    public void ButtonChatPanel()
    {
        ButtonClass.exchange(chatPanel, oldMenu);
    }

    public void ButtonAddPoint()
    {
        mapController.CallActivFieldChanged();
        ButtonClass.exchange(rootMenu, oldMenu);
        mapController.CallAddPointMapChanged(null);
    }

    public void ButtonRootAndOld() {
        mapController.CallActivFieldChanged();
        ButtonClass.exchange(rootMenu, oldMenu);


        if (Data.getDataClass().user.role.Equals(UserRole.GUIDES))
        {
            if (Data.getDataClass().getBusy().idGroup == 0) { GroupEnd.gameObject.SetActive(false); }
            else
            {
                GroupGet.gameObject.SetActive(false);
            }
        }
        else
        {

        }
        //if (!Data.getDataClass().user.role.Equals(UserRole.GUIDES))
        //{
        //   // getPos.gameObject.SetActive(false);
        //}
        //else
        //{
        //    var b = Data.getDataClass().getBusy();
        //    if (b == null || b.idPoint == 0)
        //    {
        //        getPos.gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        getPos.gameObject.SetActive(true);
        //    }
        //}
    }

	// Use this for initialization
	void Start () {
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING))
            chat.gameObject.SetActive(false);
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING) || Data.getDataClass().user.role.Equals(UserRole.GUIDES))
            addP.gameObject.SetActive(false);
        if (!Data.getDataClass().user.role.Equals(UserRole.GUIDES))
        {
            GroupEnd.gameObject.SetActive(false);
            GroupGet.gameObject.SetActive(false);
        }
        else
        {
            if (Data.getDataClass().getBusy().idGroup == 0) { GroupEnd.gameObject.SetActive(false); }
            else
            {
                GroupGet.gameObject.SetActive(false);
            }
        }
        if (Data.getDataClass().user.role.Equals(UserRole.HEAD)) generator.gameObject.SetActive(true);
        else generator.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
