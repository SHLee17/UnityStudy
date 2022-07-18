using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Bullet bullet = ObjectPooling.GetBullet();
                Vector3 dir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                bullet.transform.position = dir.normalized;
                bullet.Shoot(dir.normalized);
            }

        }
    }
}
