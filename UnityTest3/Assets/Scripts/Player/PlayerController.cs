using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
