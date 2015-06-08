using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
    public int speed_ = 10;
    public GameObject Camera;


    //public delegate void cameraMoveDelegate(bool isUp);
    //public static event cameraMoveDelegate EventCameraMove;
    //public static void CallCameraMoveChanged(bool isUp)
    //{
    //    var handler = EventCameraMove;
    //    if (EventCameraMove != null) // если есть подписчики
    //    {
    //        EventCameraMove(isUp);
    //    }
    //}

    void Start() 
    {
        //EventCameraMove+=CameraMoved;
    }

    float f = 1;
    private IEnumerator AutoMoveUp()
    {
        f = (float)0.4;
        while (true)
        {
            if (f != 0.1)
            {
                f -= (float)0.1;
            }
            CameraUp();
            WaitForSeconds ws = new WaitForSeconds(f);
            yield return ws;
        }
    }


    public void CameraMovedUp(bool isStart) 
    {
        if (isStart) StartCoroutine("AutoMoveUp"); else StopCoroutine("AutoMoveUp");
    }

    private IEnumerator AutoMoveDown()
    {
        f = (float)0.6;
        while (true)
        {
            if (f != 0.1)
            {
                f -= (float)0.1;
            }
            CameraDown();
            WaitForSeconds ws = new WaitForSeconds(f);
            yield return ws;
        }
    }


    public void CameraMovedDown(bool isStart)
    {
        if (isStart) StartCoroutine("AutoMoveDown"); else StopCoroutine("AutoMoveDown");
    }

    void CameraUp() {
        if(Camera.transform.position.z<-10)
            Camera.transform.position += Camera.transform.forward * speed_;
    }
    void CameraDown()
    {
        Camera.transform.position += Camera.transform.forward * speed_ * -1;
    }
}
