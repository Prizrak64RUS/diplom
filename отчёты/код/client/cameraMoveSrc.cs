using UnityEngine;
using System.Collections;

public class cameraMoveSrc : MonoBehaviour {
    bool isDown=false;
    public bool isMoveUp = false;
void OnMouseOver ()
{
    Debug.Log(1231);
   // if (isDown)
    //    CameraMove.CallCameraMoveChanged(isMoveUp);
}

void OnMouseDrag() 
{
    Debug.Log(1234234231);
}

void OnMouseDown()
{
    isDown = true;
}

void OnMouseUp()
{
    isDown = false;
}
}
