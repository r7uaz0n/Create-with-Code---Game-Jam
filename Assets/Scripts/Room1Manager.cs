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
    }

    private void Update()
    {
        UpdateScore();
        //Debug.Log(AnimationScript.wasCollected);
    }
    private void UpdateScore()
    {
       // if (AnimationScript.wasCollected == true)
        {
            score += score;
        }
        StarCounter.text = "Stars: " + score;
    }
}
