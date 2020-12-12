using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginButtonBehavior : MonoBehaviour
{
    public Text userNameInput;
    public Text passWordInput;

    string LoginAPI = "https://dte673qc5j.execute-api.ca-central-1.amazonaws.com/default/Login";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoginButtonPressed()
    {
        Debug.Log("Login Pressed");
        SceneManager.LoadScene("GameScene");

    }
}
