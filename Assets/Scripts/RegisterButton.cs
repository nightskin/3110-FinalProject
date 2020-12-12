using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



public class RegisterButton : MonoBehaviour
{
    public Text userNameInput;
    public Text passWordInput;

    public Image popupRef;

    string RegisterAPI = "https://sur1nzicrh.execute-api.ca-central-1.amazonaws.com/default/Register";
    string LoginAPI = "https://dte673qc5j.execute-api.ca-central-1.amazonaws.com/default/Login";


    string Username;
    string Password;

    GameObject textresp;

    // Update is called once per frame
    void Update()
    {
        Username = userNameInput.text;
        Password = passWordInput.text;


    }

    public void OnRegister()
    {
        Debug.Log("Register Pressed");
        UserRegister();
    }
    

    // public void UserLogin()
    // {
    //     StartCoroutine(GetRequest(LoginAPI));

    // }


    public void UserRegister()
    {
        StartCoroutine(GetRequest(RegisterAPI));
    }

    
    IEnumerator GetRequest(string url)
    {

        // build request
        string regURL = url + "?accountName=" + Username + "&password=" + Password;
        Debug.Log(regURL);
        UnityWebRequest webRequest = UnityWebRequest.Get(regURL);
        
        // send request
        yield return webRequest.SendWebRequest();


        // return msg
        string responseTxt = webRequest.downloadHandler.text;
        if (responseTxt == "User already exist")
        {

            Instantiate(popupRef);
            textresp =  GameObject.Find("Response");
            // textresp.text = "asdfasdf";
        }
        
        if (responseTxt == "User already exist")
        {
            
        }

        if (responseTxt == "Please enter account name and password")
        {
            
        }
    }

}
