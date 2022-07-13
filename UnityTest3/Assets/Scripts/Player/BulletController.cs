using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200.0f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) Destroy(gameObject);
    }

    public void Shoot()
    {
        rb.AddForce(new Vector3(speed, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ENEMY"))
        {
            Score temp = FindObjectOfType<Score>();
            temp.IncScore(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TARGET"))
        {
            Score tempScore = FindObjectOfType<Score>();
            tempScore.IncScore(collision.gameObject.GetComponent<Target>().Score);
            Debug.Log(collision.gameObject);
            Destroy(gameObject);
        }
    }


    
}
