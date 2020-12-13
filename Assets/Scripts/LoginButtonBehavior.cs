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


    string LoginAPI = "https://dte673qc5j.execute-api.ca-central-1.amazonaws.com/default/Login";

    // Update is called once per frame
    void Update()
    {
        Username = userNameInput.text;
        Password = passWordInput.text;
    }


    public void OnLoginButtonPressed()
    {
        Debug.Log("Login Pressed");
        // SceneManager.LoadScene("GameScene");
        UserLogin();

    }


    public void UserLogin()
    {
        StartCoroutine(GetRequest(LoginAPI));
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
        popuptext.text = responseTxt;

        Debug.Log(responseTxt);
        
        if (responseTxt == "\"Wrong user name or password\"")
        {
            Debug.Log(responseTxt);
            StartCoroutine(Popup());
        }
        
        if (responseTxt == "\"Login success\"")
        {
            // set user name to the client component
            var comp = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();
            comp.client_username = Username;

            Debug.Log(responseTxt);
            StartCoroutine(StartGame());
            // SceneManager.LoadScene("GameScene");
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
        // popupRef.gameObject.SetActive(false);
        SceneManager.LoadScene("UserProfile");
        
    }

    IEnumerator Popup()
    {
        
        popupRef.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        // popupRef.gameObject.SetActive(false);
        
    }

}
