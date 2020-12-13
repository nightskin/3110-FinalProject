using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginButtonBehavior : MonoBehaviour
{
    
    string Username;
    string Password;

    public Image popupRef;

    public Text userNameInput;
    public Text passWordInput;
    public Text popuptext;

    string responseTxt;

    bool pressed = false;
    string LoginAPI = "https://dte673qc5j.execute-api.ca-central-1.amazonaws.com/default/Login";

    int retry = 0;

    public AudioSource boop;


    // Update is called once per frame
    void Update()
    {
        Username = userNameInput.text;
        Password = passWordInput.text;

        if (responseTxt == "" && pressed)
        {
            pressed = false;
            retry++;
            Debug.Log("Reconnecting");
            StartCoroutine(GetRequest(LoginAPI));
        }

        if (retry > 10)
        {
            popuptext.text = "No Connection";
            pressed = false;
        }
    }


    public void OnLoginButtonPressed()
    {
        Debug.Log("Login Pressed");
        boop.Play(0);
        responseTxt = "";
        pressed = true;
        StartCoroutine(GetRequest(LoginAPI));

    }



    IEnumerator GetRequest(string url)
    {
        pressed = false;

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
        else
        {
            pressed = true;
        }


        popuptext.text = responseTxt;

        
        if (responseTxt == "\"Wrong user name or password\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(Popup());
        }
        
        if (responseTxt == "\"Login success\"")
        {
            Debug.Log(responseTxt);

            // set user name to the client component
            var comp = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();
            comp.client_username = Username;
            StartCoroutine(StartGame());
        }

        if (responseTxt == "\"Please enter account name and password\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(Popup());
            
        }
    }
    IEnumerator StartGame()
    {
        
        popupRef.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("UserProfile");
        
    }

    IEnumerator Popup()
    {
        
        popupRef.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        
    }

}
