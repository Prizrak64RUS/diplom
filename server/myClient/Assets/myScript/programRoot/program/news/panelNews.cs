using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.myScript.interfaceUrl;
using Assets.myScript.entity;
using System.Threading;
using System.Collections.Generic;

public class panelNews : MonoBehaviour {

    public GameObject Content;

    List<GameObject> objList;
    NewsController nc;
    int endId=0;
    public InputField textAdd;
    public Button add;
	// Use this for initialization
	void Start () {
        objList = new List<GameObject>();
        nc = new NewsController();
        var list = nc.getEndSevenNews();

        foreach (var el in list)
            addInContent(el);

        StartCoroutine("AutoNewsGet");
        //if (!Data.getDataClass().user.role.Equals(UserRole.HEAD))
        //{
        //    add.gameObject.SetActive(false);
        //    textAdd.gameObject.SetActive(false);
        //}
	}

    void addInContent(News news) 
    {
        GameObject obj = (GameObject)Instantiate(Resources.Load(("rowsNews")));
        rowsNews script = obj.GetComponent<rowsNews>();
        script.SetNews(news);
        obj.transform.parent = Content.transform;
        endId = news.id;

        objList.Add(obj);
    }

    public void ButtonAddText() 
    {
        if (textAdd.text.Equals("")) return;
        var news = new News(Data.getDataClass().eventThis.id, textAdd.text, "-");
        var contr = new NewsController();
        contr.setNews(news);
        textAdd.text = "";
    }

    private IEnumerator AutoNewsGet()
    {
        while (true)
        {
            var list = nc.getNewsOf(endId);
            foreach (var el in list)
            {
                addInContent(el);
            }
            //ClearNews();
            yield return new WaitForSeconds(10);
        }
    }

    void ClearNews() 
    {
        if (objList.Count > 25) 
        {
            int val = objList.Count - 25;
            var arr = objList.ToArray();
            for (int i = 0; i <= val; i++) 
            {
                objList.Remove(arr[i]);
                Destroy(arr[i]);
            }
        }
    }





}
