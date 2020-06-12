using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int enemyDirection = 1;
    public GameObject enemyPrefab;
    float turnTime = 0.0f;
    public Text scoreText;
    public GameObject[] healthFill;
    private int score = 0;
    int healthIndex;

    void Start()
    {
        healthIndex = healthFill.Length;
        for(int i = 0; i < 3; i++)
        {
            Instantiate(enemyPrefab, new Vector3(-4.0f + (i * 2.2f), 1.5f, 0f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector3(-4.0f + (i * 2.2f), -0.5f, 0f), Quaternion.identity);
        }
    }

    public void SetEnemyDirection()
    {
        if (Time.time > turnTime)
        {
            enemyDirection = enemyDirection * -1;
            turnTime = Time.time + 2.0f;
        }
    }

    public int GetEnemyDirection()
    {
        return enemyDirection;
    }

    public void ScorePoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void PlayerShot()
    {
        healthIndex--;
        healthFill[healthIndex].GetComponent<SpriteRenderer>().enabled = false;
    }
}
