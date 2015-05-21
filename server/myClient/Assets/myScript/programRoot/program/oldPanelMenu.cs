using UnityEngine;
using System.Collections;
using Assets.myScript.button;
using UnityEngine.UI;

public class oldPanelMenu : MonoBehaviour {


    public RectTransform rootMenu;
    public RectTransform oldMenu;
    public RectTransform newsPanel;
    public RectTransform chatPanel;

    public Button chat;
    public Button addP;
    //public GameObject addPoint;

   public void ButtonEnd()
    {
        Application.Quit();
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
    }

	// Use this for initialization
	void Start () {
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING))
            chat.gameObject.SetActive(false);
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING) || Data.getDataClass().user.role.Equals(UserRole.GUIDES))
            addP.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
