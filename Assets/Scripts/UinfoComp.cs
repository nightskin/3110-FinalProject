﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UinfoComp : MonoBehaviour
{
    
    public string client_username;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("InfoComp").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Init Uinfocomp");
        }
    }

    private void Update()
    {
        // Debug.Log(client_username);
    }

}
