using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void JoinGameOnPress()
    {
        boop.Play(0);
        
        var music = GameObject.FindGameObjectWithTag("InfoComp").GetComponent<UinfoComp>();
        music.BGMusic.Stop();

        Debug.Log("Joining Game");
        SceneManager.LoadScene("GameScene");


    }

}
