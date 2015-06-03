using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.myScript.entity;

public class pointObj : MonoBehaviour {

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
    bool isDown = false;
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
	}

    void Update()
    {
        if (isDown && DataReader.GetDataReader().isRead)
        {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                            Vector3 point = new Vector3(hit.point.x, hit.point.y, -2);
                            transform.position = point;                                //      Передаю новые координаты объекту
                    }

        }
    }

    void OnMouseDown()
    {
        isDown = true;
        if (DataReader.GetDataReader().isRead) return;
        var tex = Resources.Load<Texture2D>("material/SELECTED");
        material.mainTexture = tex;
        mapWriter.CallSelectedPointChanged(gameObject);
    }

    void OnMouseUp()
    {
        isDown = false;
        material.mainTexture = texturePrev;
        //if (DataReader.GetDataReader().isRead) return;
        //material.mainTexture = texturePrev;
    }

}
