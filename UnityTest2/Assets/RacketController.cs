using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 10;
    Vector3 startPos;
    void Start()
    {
        startPos = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        //rb.AddForce(-speed, 0, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //rb.AddForce(speed, 0, 0);

    }


}
