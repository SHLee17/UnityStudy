using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200.0f;
    float timer;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) Destroy(gameObject);
    }

    public void Shoot(PlayerController p)
    {
        Vector3 dir = p.transform.position - transform.position;
        rb.AddForce(dir * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ENEMY"))
        {

        }

    }


    
}
