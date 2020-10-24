using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room1Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI StarCounter;
    public AnimationScript animationScript;

    void Start()
    {
        score = 0;
    }

    private void Update()
    {
        UpdateScore();
        Debug.Log(animationScript.wasCollected);
    }
    private void UpdateScore()
    {
       if (animationScript.wasCollected == true)
        {
            score += score;
        }
        StarCounter.text = "Stars: " + score;
    }
}
