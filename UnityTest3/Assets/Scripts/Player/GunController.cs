using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    public BulletController bc;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletController temp = Instantiate(bc, transform.position,Quaternion.identity);
            temp.transform.localPosition += new Vector3(0.15f, 0, 0);
            temp.Shoot();
        }

    }

}
