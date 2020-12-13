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
    
    private void Start()
    {
        StartCoroutine(GetRequest(UserProfileAPI));
        

    }

    void Update()
    {
            
    }


    IEnumerator GetRequest(string url)
    {
        var comp = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();

        // build request
        string regURL = url + "?accountName=" + comp.client_username;
        Debug.Log(regURL);
        UnityWebRequest webRequest = UnityWebRequest.Get(regURL);
        
        // send request
        yield return webRequest.SendWebRequest();


        // return msg
        string responseTxt = webRequest.downloadHandler.text;
        
        
        Uprofile temp = JsonUtility.FromJson<Uprofile>(responseTxt);

        Debug.Log(temp.Death);

        
        uname.text = comp.client_username;
        ulevel.text = temp.Level.ToString();
        ukcount.text = temp.Kill.ToString();
        udcount.text = temp.Death.ToString();

        

    }
}
