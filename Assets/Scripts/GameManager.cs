using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI totalText;

    void Update()
    {
        UpdateScore();
        UpdateLives();
        UpdateKills();
        UpdateTotal();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerController.score;
    }

    public void UpdateLives()
    {
        lifeText.text = "Lives: " + PlayerController.lives;
    }
    public void UpdateKills()
    {
        killText.text = "Kills: " + PlayerController.kills;
    }
    
    public void UpdateTotal()
    {
        if (PlayerController.kills <= 0)
        {
            totalText.text = "Total Score: " + PlayerController.score;
        }
        else if (PlayerController.score <= 0)
        {
            totalText.text = "Total Score: " + PlayerController.kills;
        }
        else if (PlayerController.score > 0 && PlayerController.kills > 0)
        {
            totalText.text = "Total Score: " + PlayerController.kills * PlayerController.score;
        }
    }
}
