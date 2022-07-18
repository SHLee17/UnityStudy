using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed = 1;
    public int startIdx;
    public int endIdx;
    public Transform[] sprites;
    float viewHeight;

    void Start()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    void Update()
    {
        Move();
        
        if (sprites[endIdx].position.y < -viewHeight)
        {
            Vector3 backSpritePos = sprites[startIdx].localPosition;

            sprites[endIdx].transform.localPosition = backSpritePos + Vector3.up * viewHeight;

            int startSaveIdx = startIdx;
            startIdx = endIdx;
            endIdx = startSaveIdx - 1 == -1 ? sprites.Length - 1 : startSaveIdx - 1;
        }

    }

    private void Move()
    {
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = transform.position + nextPos;
    }
}
