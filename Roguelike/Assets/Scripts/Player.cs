using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    Animator animator;
    public int foodEnerge = 1;
    int health = 100;
    public int wallDamage = 10;


    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
            vertical = 0;
        if (vertical != 0 || vertical != 0)
        {
            AttemptMove<Wall>(horizontal, vertical);

        }
    }
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        health--;
        
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;
        if(Move(xDir,yDir,out hit))
        {

        }
    }
    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);

        animator.SetTrigger("State");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            health += foodEnerge;
        }
    }

}
