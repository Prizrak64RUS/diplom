using UnityEngine;
using System.Collections;

public class notEnableField : MonoBehaviour {

    void OnMouseDown()
    {
        DataReader.GetDataReader().isRead = true;
    }

    void OnMouseUp()
    {
        DataReader.GetDataReader().isRead = false;
    }
}
