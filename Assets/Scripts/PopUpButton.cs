using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopUpButton : MonoBehaviour
{
    public AudioSource boop;
    public Image Popup;
    // Start is called before the first frame update
    void Start()
    {
        Popup.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void popUpButton()
    {
        boop.Play(0);
        Popup.gameObject.SetActive(false);

    }
}
