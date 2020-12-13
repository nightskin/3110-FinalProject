using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignUpButtonBehavior : MonoBehaviour
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


    public void OnSignupButtonPressed()
    {

        boop.Play(0);
        Debug.Log("Signup Pressed");
        SceneManager.LoadScene("SignupScene");
        


    }
}
