using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hitTime = 3;

    SpriteRenderer sprRenderer;
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        sprRenderer.sprite = dmgSprite;

        hitTime -= loss;

        if (hitTime <= 0)
            gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
