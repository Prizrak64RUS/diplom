using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.myScript.entity;

public class rowsNews : MonoBehaviour {
    public Text date;
    public Text info;


    public void SetNews(News news) 
    {
        info.text = news.description;
        date.text = news.date_write;
    }
}
