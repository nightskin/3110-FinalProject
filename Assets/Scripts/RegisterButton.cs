using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;



public class RegisterButton : MonoBehaviour
{
    public Text userNameInput;
    public Text passWordInput;

    public Image popupRef;

    string RegisterAPI = "https://sur1nzicrh.execute-api.ca-central-1.amazonaws.com/default/Register";


    string Username;
    string Password;
    public Text popuptext;
    string responseTxt;
    bool pressed = false;



    // Update is called once per frame
    void Update()
    {
        Username = userNameInput.text;
        Password = passWordInput.text;

        // reconnect if no response
        if (responseTxt == "" && Time.frameCount % 240 == 0 && pressed)
        {
            Debug.Log("Reconnecting");
            StartCoroutine(GetRequest(RegisterAPI));
        }

    }

    public void OnRegister()
    {
        Debug.Log("Register Pressed");
        responseTxt = "";
        pressed = true;
        UserRegister();

    }
    










    public void UserRegister()
    {
        StartCoroutine(GetRequest(RegisterAPI));
    }

    
    IEnumerator GetRequest(string url)
    {
        popuptext.text = "Loading...";
        popupRef.gameObject.SetActive(true);

        // build request
        string regURL = url + "?accountName=" + Username + "&password=" + Password;
        Debug.Log(regURL);
        UnityWebRequest webRequest = UnityWebRequest.Get(regURL);
        
        // send request
        yield return webRequest.SendWebRequest();
        

        // return msg
        responseTxt = webRequest.downloadHandler.text;


        // stop reconnecting
        if (responseTxt != "")
        {
            pressed = false;
        }


        // set popup text
        popuptext.text = responseTxt;
        

        // return response to client
        if (responseTxt == "\"User already exist\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(Popup());
        }
        
        if (responseTxt == "\"Registration success\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(MEnu());

        }

        if (responseTxt == "\"Please enter account name and password\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(Popup());
        }
    }


    IEnumerator MEnu()
    {
        
        popupRef.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoginScene");

    }


    IEnumerator Popup()
    {
        popupRef.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
    }

}
