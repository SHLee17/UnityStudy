using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlightType
{
    Triangle,
    Rect
}

public abstract class Flight : MonoBehaviour
{
    protected FlightType type;
    protected string name;
    protected float hp;
    protected float power;
    protected float speed;
    protected GameObject player;


    public Sprite[] sprites;

    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected SpriteRenderer sprRenderer;
    [SerializeField]
    Bullet bullet;

    public int dmgPoint;
    public GameManager gm;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRenderer = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }
    public abstract void Attack();
    public abstract void SetPlayer(GameObject player);
    public abstract void Move();

    public IEnumerator FireBullet()
    {
        WaitForSeconds waitFor = new WaitForSeconds(1);
        while (true)
        {
            yield return waitFor;
            //Bullet temp = gm.objManager.MakeObject("EnemyBullet").GetComponent<Bullet>();
            Bullet temp = Instantiate(bullet);
            Debug.Log(temp);
            if (temp != null)
            {
                temp.transform.position = transform.position;
                Vector3 dirVec = player.transform.position - transform.position;
                temp.rb.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
            }
        }
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
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            gameObject.SetActive(false);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            gm.Score = dmgPoint;
            collision.gameObject.SetActive(false);
            //Bullet temp = collision.gameObject.GetComponent<Bullet>();
            //hp -= temp.power;
            ////Destroy(temp.gameObject);
            //temp.gameObject.SetActive(false);
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
}


public abstract class FlightGenerator
{
    public List<Flight> flightList = new List<Flight>();

    public List<Flight> getFlightList() { return flightList; }

    public abstract void CreateFlight();
}

class TriangleFlightGenerator : FlightGenerator
{
    public override void CreateFlight()
    {
        flightList.Clear();
        flightList.Add(new TriangleFlight());
        flightList.Add(new TriangleFlight());
        flightList.Add(new TriangleFlight());
    }
}

class RectFlightGenerator : FlightGenerator
{
    public override void CreateFlight()
    {
        flightList.Clear();
        flightList.Add(new RectFlight());
        flightList.Add(new RectFlight());
        flightList.Add(new RectFlight());
    }
}

class UseFactory : MonoBehaviour
{
    FlightGenerator[] unitGenerator = null;

    private void Start()
    {
        unitGenerator = new FlightGenerator[2];
        unitGenerator[0] = new TriangleFlightGenerator();
        unitGenerator[1] = new RectFlightGenerator();
    }
    //void Make
}