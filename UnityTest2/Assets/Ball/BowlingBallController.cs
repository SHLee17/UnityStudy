using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 200;
    Vector3 startPos;
    void Start()
    {
        startPos = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-speed, 0 , speed);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WALL"))
        {
            Vector3 currPos = transform.position;
            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);

            reflectVec = reflectVec.normalized;

            rb.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}
