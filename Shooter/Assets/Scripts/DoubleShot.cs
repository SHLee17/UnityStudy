using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IWeapon
{
    void Shoot(GameObject obj, GameObject player);
}
public class DoubleShot : MonoBehaviour, IWeapon
{
    public void Shoot(GameObject obj, GameObject player)
    {
        GameObject bullet = Instantiate(obj);
        bullet.transform.position = player.transform.position;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            gameObject.SetActive(false);
    }
}
