using UnityEngine;
using System.Collections;
using RestSharp;

public class StartPanelButtonScript : MonoBehaviour {
    public Transform authPanel;
    public Transform connectPanel;
    public Transform startPanel;
	public void Exit () {
        Application.Quit();
	}

    public void startInConnect() {
        exchange(startPanel, connectPanel);
    }

    public void connectInAuth() {
        var client = new RestClient("http://localhost:8080/test/");
        var request = new RestRequest(Method.GET);
        var response = client.Execute(request);
        var content = response.Content;
        Debug.Log(content);
        exchange(connectPanel, authPanel);
    }

    public void auth() { }

    private void exchange(Transform x1,Transform x2) {
        var trans = x1.position;
        x1.position = x2.position;
        x2.position = trans;
    }
}
