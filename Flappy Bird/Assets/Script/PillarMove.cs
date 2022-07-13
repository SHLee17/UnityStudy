using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMove : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        
    }
    float speed = 10;
    private void FixedUpdate()
    {
        speed = Time.deltaTime * 5;

        transform.position = new Vector2(transform.position.x - speed,
            transform.position.y);
    }
}
