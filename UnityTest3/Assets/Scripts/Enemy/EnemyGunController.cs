using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    
    public EnemyBulletController ebc;
    public PlayerController player;
    Vector3 dir;
    float timer;
    void Update()
    {
        //dir = player.transform.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(dir);
        transform.LookAt(player.transform);

        timer += Time.deltaTime;
        if (timer > 3) 
        {
            EnemyBulletController temp = Instantiate(ebc, transform.position,Quaternion.identity);
            temp.transform.position += new Vector3(-0.6f, 0, 0);
            temp.Shoot(player);
            timer = 0;
        }

    }

}
