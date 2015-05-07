using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.myScript.entity;

public class pointObj : MonoBehaviour {

    public Point point { get; set; }
    //bool isDown = false;
	// Use this for initialization
	void Start () {
	
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
        mapWriter.CallSelectedPointChanged(gameObject);
    }

    //void OnMouseUp()
    //{
    //    isDown = false;
    //    //mapWriter.CallSelectedPointChanged(null);
    //}

}
