using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xVelocity = 0f;
    public float yVelocity = -5.0f;
    Vector3 screenPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);

        // Check if off screen and destroy
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.x > Screen.width
            || screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
