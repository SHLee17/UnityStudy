using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    SpriteRenderer sprRenderer;
    [SerializeField]
    Bullet bullet;

    public GameObject player;
    public float speed;
    public Rigidbody2D rb;
    public float hp;

    public int dmgPoint;

    public GameManager gm;

    void Start()
    {
        dmgPoint = 100;
        hp = 2;
        //StartCoroutine(FireBullet());
    }
    public IEnumerator FireBullet()
    {
        WaitForSeconds waitFor = new WaitForSeconds(1);
        while (true)
        {
            yield return waitFor;
            Bullet temp = gm.objManager.MakeObject("EnemyBullet").GetComponent<Bullet>();

            if (temp != null)
            {
                temp.transform.position = transform.position;
                Vector3 dirVec = player.transform.position - transform.position;
                temp.rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
            }
        }
    }

    private void Update()
    {
        
    }
    IEnumerator HitSprite()
    {
        for (int i = 0; i < 5; i++)
        {
            sprRenderer.sprite = sprites[1];
            
            Debug.Log(sprRenderer.sprite.name);
            yield return new WaitForSeconds(.1f);
            sprRenderer.sprite = sprites[0];
            Debug.Log(sprRenderer.sprite.name);
            yield return new WaitForSeconds(.1f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            gameObject.SetActive(false);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            gm.Score = dmgPoint;
            Bullet temp = collision.gameObject.GetComponent<Bullet>();
            hp -= temp.power;
            //Destroy(temp.gameObject);
            temp.gameObject.SetActive(false);
            if (hp <= 0)
            {
                hp = 2;
                sprRenderer.sprite = sprites[0];
                gameObject.SetActive(false);
            }
            else
                StartCoroutine(HitSprite());
        }
    }


    private void OnDisable()
    {
        StopCoroutine(FireBullet());   
    }
}
