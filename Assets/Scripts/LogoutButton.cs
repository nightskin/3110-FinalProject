﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{
    public AudioSource boop;

    void Start()
    {
        
    }

    public void LogoutOnPress()
    {
        var comp = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();
        comp.client_username = "";
        SceneManager.LoadScene("LoginScene");
        // boop.Play(0);
    }

}
