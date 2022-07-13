using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    enum Actions
    {
        jump,
        walk,
        idle,
        none
    }
    Animator animator;
    Rigidbody2D rb;
    float walkSpeed = 10.0f;
    Actions temp = Actions.idle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            animator.SetBool("isWalking", false);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            temp = Actions.jump;
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            animator.SetInteger("aaa", (int)Actions.jump);
        }
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x >= -4)
                transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);

            transform.localScale = new Vector2(-1, 1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= 4)
                transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

            transform.localScale = new Vector2(1, 1);
            animator.SetBool("isWalking", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            if (temp == Actions.jump)
            {
                animator.SetInteger("aaa", (int)Actions.idle);
                temp = Actions.none;
            }
        }
    }

}
