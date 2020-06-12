using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 screenPos;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPos.x < 0 || screenPos.y < 0 || screenPos.x > Screen.width 
            || screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            gameController.ScorePoint();
        }
    }
}
