using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    void Start()
    {
        hp = 10;
        speed = 1;

        
    }

    void Update()
    {

    }

    void BossFireBullet()
    {
        for (int i = -20; i <= 20; i+=10)
        {
            Bullet temp = gm.objManager.MakeObject("EnemyBullet").GetComponent<Bullet>();

            temp.transform.position = transform.position;

            temp.transform.rotation = Quaternion.Euler(0, 0, i);

            temp.rb.AddForce(Vector2.down, ForceMode2D.Impulse);
        }
        

    }
    public IEnumerator Stop(float n)
    {
        yield return new WaitForSeconds(n);
        rb.velocity = Vector2.zero;

        InvokeRepeating("BossFireBullet", 1, 2);
    }

}
