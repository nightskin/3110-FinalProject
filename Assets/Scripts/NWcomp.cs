using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

[System.Serializable]
public class ClientInGameData
{
    public int m_Xpos;
    public int m_Ypos;
    
    // public Vector2[] m_bulletPos;
}



[System.Serializable]
public class Room
{
    ClientInGameData[] LocalPlayer;
}



[System.Serializable]
public class ClientData
{
    public int Level;
    public int Death;
    public string Password;
    public string Accountname;
    public int Kill;
}


public class NWcomp : MonoBehaviour
{

    Room LocalGame;

    UinfoComp uinfoRef;

    public GameObject playerPrefabRef;

    public UdpClient udp;
    
    ClientInGameData serverData;



    void Start()
    {
        Debug.Log("Connecting...");

        // get user info component
        // uinfoRef = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();

        // Connect to the client.
        udp = new UdpClient();
        udp.Connect("3.96.203.122", 12345);

        // receive message from the server
        udp.BeginReceive(new AsyncCallback(OnReceived), udp);

        // send to server
        Byte[] sendBytes = Encoding.ASCII.GetBytes("connected");
        udp.Send(sendBytes, sendBytes.Length);

        // Repeat calling (Method, time, repeatRate)
        InvokeRepeating("HeartBeat", 1, 1);
    }




    void OnReceived(IAsyncResult result)
    {
        // this is what had been passed into BeginReceive as the second parameter:
        UdpClient socket = result.AsyncState as UdpClient;

        // points towards whoever had sent the message:
        IPEndPoint source = new IPEndPoint(0, 0);

        // get the actual message and fill out the source:
        byte[] message = socket.EndReceive(result, ref source);
        
        // do what you'd like with `message` here:
        string returnData = Encoding.ASCII.GetString(message);
        Debug.Log(returnData);


        // serverData = JsonUtility.FromJson<ClientInGameData>(returnData);
        // Debug.Log(serverData);



    }



    // send player info to server
    void HeartBeat()
    {
        // Byte[] sendBytes = Encoding.ASCII.GetBytes("Hearbeat" + uinfoRef.client_username);
        Byte[] sendBytes = Encoding.ASCII.GetBytes("Hearbeat");
        udp.Send(sendBytes, sendBytes.Length);
        Debug.Log("HeartBeat");

        
    }

    // send player position on this client to server
    void SendPosition()
    {
        // create pos object
        // ClientInGameData currPos = new ();


        // Debug.Log($"{currX},{currY}, {currZ}");


        // send to server
        Byte[] senddata = Encoding.ASCII.GetBytes(JsonUtility.ToJson("Hearbeat" + uinfoRef.client_username));
        udp.Send(senddata, senddata.Length);

    }



    void OnDestroy()
    {
        udp.Dispose();
    }
}
