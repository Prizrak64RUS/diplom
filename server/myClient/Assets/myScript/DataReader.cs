using UnityEngine;
using System.Collections;
using Assets.myScript.entity;
using System.Collections.Generic;

public class DataReader : MonoBehaviour {
    public List<Maps> mapList { get; set; }
    public string patch { get; set; }
    public Maps selectedMap { get; set; }
}
