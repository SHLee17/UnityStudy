using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public ParticleSystem ps;

    public float mySpeed = 10;
    public float foSpeed = 150;

    public int playerNum = 1;
    string mvAxisName;
    string roAxisName;
    // Start is called before the first frame update
    void Start()
    {
        mvAxisName = "Vertical" + playerNum;
        roAxisName = "Horizontal" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        float mv = Input.GetAxis(mvAxisName) * mySpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * foSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            ParticleSystem temp= Instantiate(ps, transform.position, transform.rotation);
            temp.Play();
            Destroy(gameObject);
        }

    }
}
