using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    float speed = 0;

    void Update()
    {
        speed = Time.deltaTime * 10;
        transform.Translate(direction);   
    }

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        Invoke("ReturnBulletPooling", 5.0f);
    }
    public void ReturnBulletPooling()
    {
        ObjectPooling.ReturnObject(this);
    }

}
