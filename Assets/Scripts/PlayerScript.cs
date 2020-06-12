using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
