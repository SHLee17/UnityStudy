using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectFlight : Flight
{
    public RectFlight()
    {
        type = FlightType.Triangle;
        name = "EnemyC";
        hp = 2;
        power = 5;
        speed = 2;
    }
    protected override void Start()
    {
        base.Start();
        dmgPoint = 100;
    }

    public override void Attack()
    {

    }

    public override void Move()
    {
        rb.velocity = new Vector2(0, speed * -1);

    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }


    void Update()
    {
        
    }
}
