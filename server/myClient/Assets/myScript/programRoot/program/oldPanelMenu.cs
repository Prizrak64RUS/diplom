using UnityEngine;
using System.Collections;
using Assets.myScript.button;

public class oldPanelMenu : MonoBehaviour {


    public RectTransform rootMenu;
    public RectTransform oldMenu;
    public RectTransform newsPanel;

    public GameObject chat;
    public GameObject addPoint;

    public void ButtonNewsPanel() {
        ButtonClass.exchange(newsPanel, oldMenu);
    }

    public void ButtonRootAndOld() {
        mapController.CallActivFieldChanged();
        ButtonClass.exchange(rootMenu, oldMenu);
    }

	// Use this for initialization
	void Start () {
        if (Data.getDataClass().user.role.Equals(UserRole.WATCHING))
            chat.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
