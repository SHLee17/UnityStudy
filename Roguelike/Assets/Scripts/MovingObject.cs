using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f;

    bool isMoving;
    BoxCollider2D boxCollider;
    Rigidbody2D rb;
    LayerMask blockingLayer;
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();
    }

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (hit.transform == null && !isMoving)
            return true;

        return false;
    }

    protected virtual void AttemptMove<T> (int xDir, int yDir)where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(xDir, yDir, out hit);

        if (hit.transform == null)
            return;
        T hitComponet = hit.transform.GetComponent<T>();

        if (!canMove && hitComponet != null)
            OnCantMove(hitComponet);

    }

    protected abstract void OnCantMove<T>(T component) where T : Component;

    void Update()
    {
        
    }
}
