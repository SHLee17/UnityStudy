using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{

    public Rigidbody Shell;
    public Transform fire;
    public int fireNum;
    string fireKey;

    void Start()
    {
        fireKey = "Fire" + fireNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireKey))
        {
            Rigidbody shellInstance = Instantiate(Shell, fire.position, fire.rotation);


            shellInstance.velocity = 20.0f * fire.forward;
        }
    }
}
