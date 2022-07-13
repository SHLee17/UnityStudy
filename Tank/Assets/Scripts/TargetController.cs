using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ParticleSystem ps;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            ParticleSystem temp = Instantiate(ps, transform.position, transform.rotation);
            temp.Play();
            Destroy(gameObject);
        }
    }
}
