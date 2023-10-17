using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private float horizontal;
    public float speed = 5f;
    public float distance = 2f;
    private bool isFacingRight = true;

    private Vector3 startPos;
    private bool moveRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moveRight)
        {
            horizontal = -1; // Moving to the right
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x >= startPos.x + distance)
            {
                moveRight = false;
            }
        }
        else
        {
            horizontal = 1; // Moving to the left
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x <= startPos.x)
            {
                moveRight = true;
            }
        }

        Flip();
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
