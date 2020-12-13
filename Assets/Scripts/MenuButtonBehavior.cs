using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehavior : MonoBehaviour
{
    public AudioSource boop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuButtonPressed()
    {

        boop.Play(0);
        Debug.Log("Menu Pressed");
        SceneManager.LoadScene("LoginScene");
        


    }
}
