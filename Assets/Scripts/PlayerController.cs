using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 40.0f;

    public Rigidbody2D rb;
    public Camera cam;
    public float threshold;


    public AudioSource BGMusic;

    float distanceToMouse;
    Vector2 mousePosition;
    float angle;
    void Start()
    {
        BGMusic.Play(0);
    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = new Vector2(mousePosition.x, mousePosition.y);
        distanceToMouse = Vector2.Distance(pos, mousePosition);
        angle = -Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            
        if (Input.GetMouseButton(1)) // if right click
        {
            if (distanceToMouse >= threshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}