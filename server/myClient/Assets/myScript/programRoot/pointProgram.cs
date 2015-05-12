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
    }

    public Point GetPoint()
    {
        return point;
    }
    //bool isDown = false;
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
	}

    void Update()
    {
        //if (isDown) 
        //{
        //   // Debug.Log("x = " + Input.mousePosition.x + " y = " + Input.mousePosition.y);
        //    //this.gameObject.transform.position = Input.mousePosition; //new Vector3(Input.mousePosition.x/1000,Input.mousePosition.y/1000,-1);
        //    //Input.
        //}
       // Camera.transform.position += Camera.transform.right * deltaX * Time.deltaTime * Camera.transform.position.z * -1 / 100;

       // Camera.transform.position += Camera.transform.up * deltaY * Time.deltaTime * Camera.transform.position.z * -1 / 100;
    }

    void OnMouseDown()
    {
        if (Data.getDataClass().isRead) return;
        var tex = Resources.Load<Texture2D>("material/"+PointType.SELECTED);
        texturePrev = material.mainTexture;
        material.mainTexture = tex;
    }


    void OnMouseUp()
    {
        if (DataReader.GetDataReader().isRead) return;
        material.mainTexture = texturePrev;
        switch (point.type)
        {
            case PointType.INFO:
            case PointType.ACTION:
                {
                    infoPanel.CallSelectedPointChanged(point);
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

