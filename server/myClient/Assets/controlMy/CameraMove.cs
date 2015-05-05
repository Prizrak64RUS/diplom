using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
    public int speed_ = 10;
    public GameObject Camera;


    public void ButtonCameraUp() {
        if(Camera.transform.position.z<-10)
            Camera.transform.position += Camera.transform.forward * speed_;
    }
    public void ButtonCameraDown()
    {
        Camera.transform.position += Camera.transform.forward * speed_ * -1;
    }
}
