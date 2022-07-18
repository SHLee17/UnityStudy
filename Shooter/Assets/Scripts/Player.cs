using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    enum Direction
    {
        Left,Right,Top,Bottom
    }
    Dictionary<Direction, bool> directionCheck;

    [SerializeField]
    Animator animator;
    [SerializeField]
    float speed;
    [SerializeField]
    Bullet bullet;
    [SerializeField]
    uint life = 3;

    [SerializeField]
    float currentBulletDelay;
    [SerializeField]
    float maxBulletDelay;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    bool[] isButton;

    bool isControl;
    public bool isHit;


    void Start()
    {
        maxBulletDelay = 0;
        directionCheck = new Dictionary<Direction, bool>();
        for (Direction i = 0; i <= Direction.Bottom; i++)
            directionCheck.Add(i, false);
    }

    void Update()
    {
        #region Move
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        animator.SetInteger("Horizontal", (int)h);

        if (isControl)
        {
            if (isButton[0])
            { h = -1; v = 1; }
            else if (isButton[1])
            { v = 1; h = 0; }
            else if (isButton[2])
            { v = -1; h = 1; }
            else if (isButton[3])
            { v = 0; h = -1; }
            else if (isButton[4])
            { h = 0; v = 0; }
            else if (isButton[5])
            { v = 0; h = 1; }
            else if (isButton[6])
            { v = -1; h = -1; }
            else if (isButton[7])
            { v = -1; h = 0; }
            else if (isButton[8])
            { v = -1; h = 1; }
        }
        else
        {
            if (directionCheck[Direction.Left] && h == -1 || directionCheck[Direction.Right] && h == 1)
                h = 0;
            if (directionCheck[Direction.Top] && v == 1 || directionCheck[Direction.Bottom] && v == -1)
                v = 0;
        }
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
        #endregion

        #region Fire
        if (Input.GetButton("Fire1"))
        {
            currentBulletDelay += Time.deltaTime;

            if (currentBulletDelay < maxBulletDelay)
                return;

            Bullet tempBullet = gm.objManager.MakeObject("PlayerBullet").GetComponent<Bullet>();
            tempBullet.transform.position = transform.position;
            tempBullet.rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            currentBulletDelay = 0;
            maxBulletDelay = 0.2f;

        }
        #endregion
    }
    public void JoyPanel(int type)
    {
        for (int idx = 0; idx < 9; idx++)
        {
            isButton[idx] = idx == type;
        }
    }

    public void JoyDown()
    {
        isControl = true;
    }

    public void JoyUp()
    {
        isControl = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Bottom":
                    directionCheck[Direction.Bottom] = true;
                    break;
                case "Top":
                    directionCheck[Direction.Top] = true;
                    break;
                case "Left":
                    directionCheck[Direction.Left] = true;
                    break;
                case "Right":
                    directionCheck[Direction.Right] = true;
                    break;
            }
        }
    
        if(collision.gameObject.tag == "Bullet")
        {
            if (!isHit)
            {
                life--;

                if (life > 0)
                    gm.ReSpawnPlayer();
                else
                    gm.GameOver();

            }
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Bottom":
                    directionCheck[Direction.Bottom] = false;
                    break;
                case "Top":
                    directionCheck[Direction.Top] = false;
                    break;
                case "Left":
                    directionCheck[Direction.Left] = false;
                    break;
                case "Right":
                    directionCheck[Direction.Right] = false;
                    break;
            }
        }
    }
}
