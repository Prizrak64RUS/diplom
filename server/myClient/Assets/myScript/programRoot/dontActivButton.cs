using UnityEngine;
using System.Collections;

public class dontActivButton : MonoBehaviour {

	void Update () {
        if (!mapWriter.isSelectedObj()) {
            gameObject.SetActive(false);
        }
	}
}
