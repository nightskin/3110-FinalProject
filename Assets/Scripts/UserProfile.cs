using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class Uprofile
{
    public int Level;
    public int Death;
    public string Password;
    public string Accountname;
    public int Kill;

}



public class UserProfile : MonoBehaviour
{
    string UserProfileAPI = "https://4ds556sbfl.execute-api.ca-central-1.amazonaws.com/default/GetPlayerDetail";

    public Text uname;
    public Text ulevel;
    
    public Text ukcount;
    public Text udcount;
    


    UinfoComp comp;
    UnityWebRequest webRequest;
    string responseTxt;
    Uprofile temp;
    bool refreshing;

    private void Start()
    {
        responseTxt = "";
        StartCoroutine(GetRequest(UserProfileAPI));
    
    }

    void Update()
    {
        if (responseTxt == "" && !refreshing )
        {
            Debug.Log("Reconnecting");
            StartCoroutine(GetRequest(UserProfileAPI));
        }
        
    }


    IEnumerator GetRequest(string url)
    {
        refreshing = true;
        // get user info component
        comp = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();

        // build request
        string regURL = url + "?accountName=" + comp.client_username;
        Debug.Log(regURL);
        webRequest = UnityWebRequest.Get(regURL);
        var send = webRequest.SendWebRequest();
        Debug.Log(send);

        // send request
        yield return send;

        Debug.Log("got response");
        // get response
        responseTxt = webRequest.downloadHandler.text;
        
        if (responseTxt != "")
        {
            refreshing = false;    
        }

        // reaplicate json response
        temp = JsonUtility.FromJson<Uprofile>(responseTxt);



        uname.text = comp.client_username;
        if (temp != null)
        {
            ulevel.text = temp.Level.ToString();
            ukcount.text = temp.Kill.ToString();
            udcount.text = temp.Death.ToString();
            
        }


        
        

    }
}
