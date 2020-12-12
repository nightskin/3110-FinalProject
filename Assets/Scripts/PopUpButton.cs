using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopUpButton : MonoBehaviour
{

    public Image Popup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void popUpButton()
    {
        Destroy(Popup.gameObject);
    }
}
