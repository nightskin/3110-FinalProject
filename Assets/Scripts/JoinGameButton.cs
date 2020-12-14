using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JoinGameButton : MonoBehaviour
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

    public void OnJoinGamePressed()
    {
        boop.Play(0);
        SceneManager.LoadScene("GameScene");
    }
}
