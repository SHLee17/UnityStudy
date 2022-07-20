using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFlight : Flight
{
    public TriangleFlight()
    {
        type = FlightType.Triangle;
        name = "EnemyA";
        hp = 2;
        power = 5;
        speed = 2;
        Debug.Log("»ý¼ºÀÚ");
    }
    protected override void Start()
    {
        base.Start();
        dmgPoint = 200;
    }
    void Update()
    {

    }
    public override void Attack()
    {
        StartCoroutine(FireBullet());
    }

    public override void Move()
    {
        rb.velocity = new Vector2(0, speed * -1);
    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

}
