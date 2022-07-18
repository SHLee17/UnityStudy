using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 200);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "score")
        {
            FindObjectOfType<GameManager>().Score++;
            Destroy(collision.gameObject);
        }
    }
}
