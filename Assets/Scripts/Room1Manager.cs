using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room1Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI StarCounter;

    void Start()
    {
        score = 0;
        StarCounter.text = "Stars: " + score;
    }

    private void Update()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        if (GameState.didCollectKey1 == true)
        {
            score++;

        }
    }
}
