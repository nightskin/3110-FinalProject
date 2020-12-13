using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]


public class ClientInGameData
{
    public Vector2 m_pos;
    public Vector2[] m_bulletPos;
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

    ClientInGameData[] LocalPlayer;
    
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
