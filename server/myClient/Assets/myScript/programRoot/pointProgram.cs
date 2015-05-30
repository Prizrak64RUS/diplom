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
        string type = null; ;
        switch (point.type)
        {
            case PointType.INFO:
            case PointType.NOT_ACTION:
            case PointType.NEXT:
                {
                    type = "material/" + point.type;
                    break;
                }
            case PointType.ACTION:
                {
                    type = "material/" + point.type;
                    if (point.busy == 1) type += "Z";
                    break;
                }
            case PointType.GROUP:
                {
                    type = "material/" + point.type;
                    if (point.busy == 1) type += "Z";
                    break;
                }
            case PointType.PORTER_POSITION:
                {
                    type = "material/" + point.type;
                    if (point.busy == 1) type += "Z";
                    break;
                }

        }

        if (gameObject.transform.localPosition.x != point.x || gameObject.transform.localPosition.y != point.y) 
        {

            gameObject.transform.localPosition = new Vector3(point.x, point.y, (float)0);
        }

        if (gameObject.transform.localScale.x != point.size_w || gameObject.transform.localScale.y != point.size_h)
        {
            gameObject.transform.localScale = new Vector3(point.size_w, point.size_h, (float)2);
        }

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
                {
                    infoPanel.CallSelectedPointChanged(point);
                    break;
                }
            case PointType.GROUP:
                {
                    //if (Data.getDataClass().user.role.Equals(UserRole.GUIDES) || Data.getDataClass().user.role.Equals(UserRole.HEAD))
                    //{
                        infoPanel.CallSelectedPointChanged(point);
                    //}
                    //else
                    //{
                    //    if (point.id_user_Busy == Data.getDataClass().user.id)
                    //    {
                    //        mapController.CallAddPointMapChanged(this);
                    //        infoPanel.CallSelectedPointChanged(point);
                    //    }
                    //}
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

