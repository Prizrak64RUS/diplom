using UnityEngine;
using System.Collections;

public class rowsMaps : MonoBehaviour {

    public UnityEngine.UI.InputField description;
    public UnityEngine.UI.Button type;
    public UnityEngine.UI.InputField name;


    public delegate void mapTypeEventSetNameDelegate(string val);
    public static event mapTypeEventSetNameDelegate EventMapTypeEventSetName;
    public static void CallmapTypeEventSetNameChanged(string val)
    {
        var handler = EventMapTypeEventSetName;
        if (EventMapTypeEventSetName != null) // если есть подписчики
        {
            EventMapTypeEventSetName(val);
        }
    }
	// Use this for initialization
	void Start () {
	
	}

}
