using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoseCollider : MonoBehaviour {

    private LevelManager levelmanager;
    private Text lives;
    public int maxLives;
    private Ball ball;
    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        lives = GameObject.FindObjectOfType<Text>();
        lives.text = "Lives: " + maxLives;
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (--maxLives == 0)
        {
            Block.breakableCount = 0;
            levelmanager.LoadLevel("Lose Screen");
        }
        else
        {
            ball.HasStarted = false;
           lives.text = "Lives: " + maxLives;
        }
            
    }
}
