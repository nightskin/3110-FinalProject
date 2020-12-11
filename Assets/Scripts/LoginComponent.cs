using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoginComponent : MonoBehaviour
{

    // public UdpClient udp;

    string RegisterAPI = "https://sur1nzicrh.execute-api.ca-central-1.amazonaws.com/default/Register";
    string LoginAPI = "https://dte673qc5j.execute-api.ca-central-1.amazonaws.com/default/Login";

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UserLogin()
    {
        StartCoroutine(GetRequest(LoginAPI));

    }


    public void UserRegister()
    {
        StartCoroutine(GetRequest(RegisterAPI));

    }

    
    IEnumerator GetRequest(string url)
    {

        yield return url;
    }

}
