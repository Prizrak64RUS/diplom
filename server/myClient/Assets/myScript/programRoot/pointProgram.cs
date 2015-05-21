using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using UnityStandardAssets.CrossPlatformInput;
using Assets.myScript.interfaceUrl;
using System.Collections.Generic;


public class pointProgram : MonoBehaviour {

    Material material;
    Texture texturePrev;
    Point point { get; set; }

    public void SetPoint(Point point) {
        this.point = point;
        string type = "material/" +point.type;
        var tex = Resources.Load<Texture2D>(type);
        if (material == null) { material = GetComponent<Renderer>().material;  }
        material.mainTexture = tex;
        texturePrev = material.mainTexture;
    }

    public Point GetPoint()
    {
        return point;
    }
	void Start () {
        material = GetComponent<Renderer>().material;
	}

    void OnMouseDown()
    {
        if (Data.getDataClass().isRead) return;
        var tex = Resources.Load<Texture2D>("material/"+PointType.SELECTED);
        material.mainTexture = tex;
    }


    void OnMouseUp()
    {
        material.mainTexture = texturePrev;
        if (Data.getDataClass().isRead) return;
        
        switch (point.type)
        {
            case PointType.INFO:
            case PointType.ACTION:
            case PointType.NOT_ACTION:
            case PointType.GROUP:
                {
                    infoPanel.CallSelectedPointChanged(point);
                    break;
                }
            case PointType.PORTER_POSITION:
                {
                    if (Data.getDataClass().user.role.Equals(UserRole.PORTER))
                    {
                        infoPanel.CallSelectedPointChanged(point);
                    }
                    else
                    {
                        mapController.CallAddPointMapChanged(this);
                    }
                    break;
                }
            case PointType.NEXT:
                {
                    mapController.CallMapBuildChanged(new Maps(point.id_user_Busy));
                    break;
                }
        }
    }

}

