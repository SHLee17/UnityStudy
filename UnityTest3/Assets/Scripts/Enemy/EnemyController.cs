using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 2;
    public Rigidbody rb;

    float length = 2f;
    float timer = 0;
    float zPos = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime * speed;
        zPos = Mathf.Sin(timer) * length;

        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
}
