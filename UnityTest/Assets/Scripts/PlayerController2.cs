using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(-speed , 0 , 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(speed, 0, 0);
        else if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(0, 0, speed);
        else if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(0, 0, -speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("123");
            rb.AddForce(0, speed, 0);
        }
        //else if (Input.GetKeyUp(KeyCode.Space))
        //    rb.AddForce(0, -speed, 0);






    }
}
