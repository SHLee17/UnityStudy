using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem shellExplosion;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem fire = Instantiate(shellExplosion, transform.position, transform.rotation);
        fire.Play();
        Destroy(gameObject);
    }
}
