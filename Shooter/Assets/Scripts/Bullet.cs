using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{

    public float power;
    public Rigidbody2D rb;
    private void Start()
    {
    }

    void Update()
    {
        //transform.Translate(Vector2.down * 5 * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
                
    }
}
