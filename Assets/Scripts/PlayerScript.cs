using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isRightPressed = false;
    private bool isLeftPressed = false;
    public float moveSpeed = 5f;
    Vector3 pos;

    private void Update()
    {
        isRightPressed = Input.GetKey(KeyCode.RightArrow);
        isLeftPressed = Input.GetKey(KeyCode.LeftArrow);
    }

    private void FixedUpdate()
    {
        pos = transform.position;
        if (isRightPressed)
        {
            pos.x += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
        if (isLeftPressed)
        {
            pos.x -= moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            collision.gameObject.GetComponent<LaserScript>().yVelocity = 0f;
            collision.gameObject.GetComponent<Animator>().Play("Hit");
            GameObject.Find("GameController").GetComponent<GameController>().PlayerShot();
        }
    }
}
