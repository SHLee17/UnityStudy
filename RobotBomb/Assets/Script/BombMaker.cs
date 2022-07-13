using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaker : MonoBehaviour
{
    public GameObject objBomb;
    public float interval = 1.0f;
    void Start()
    {
        StartCoroutine(BombDrop(interval));
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    IEnumerator BombDrop(float n)
    {
        while (true)
        {
            GameObject bomb = Instantiate(objBomb);
            int x = Random.Range(-5, 5);

            bomb.transform.position = new Vector2(x, 3);
            yield return new WaitForSeconds(n);
        }
    }
}
