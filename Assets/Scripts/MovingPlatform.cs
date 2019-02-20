using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool vertical, horizontal, rightDiagonal, leftDiagonal, SquareMovement;
    /// <summary>The objects initial position.</summary>
    private Vector2 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector2 newPosition;

    /// <summary>The speed at which the object moves.</summary>
    [SerializeField] private float speed = 3;
    /// <summary>The maximum distance the object may move in either y direction.</summary>
    [SerializeField] private float maxDistance = 1;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        if (horizontal)
        {
            newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
            transform.position = newPosition;
        }
        if (vertical)
        {
            newPosition.y = startPosition.y + (maxDistance * Mathf.Sin(Time.time * speed));
            transform.position = newPosition;
        }
        if (rightDiagonal) {
            horizontal = true;
            vertical = true;
        }

        if (leftDiagonal) {
            newPosition.x = startPosition.x - (maxDistance * Mathf.Sin(Time.time * speed));
            newPosition.y = startPosition.y + (maxDistance * Mathf.Sin(Time.time * speed));
            transform.position = newPosition;
        }
        else
        {
            transform.position = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.collider.transform.SetParent(null);
        }
    }
}
