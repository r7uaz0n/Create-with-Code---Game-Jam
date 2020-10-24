using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room1Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI StarCounter;
    public Player player;
    public GameObject Roominstructions;

    //public AnimationScript animationScript;

    void Start()
    {
        score = 0;
    }

    private void Update()
    {
        UpdateScore();
        //      Debug.Log(animationScript.wasCollected);
        if (player.activeInstructions == true)
        {
            Roominstructions.SetActive(true);
            StartCoroutine(PickInstructions());
        }

    }

    IEnumerator PickInstructions()
    {
        yield return new WaitForSeconds(3);
        player.activeInstructions = false;
        Roominstructions.SetActive(false);
    }
    public void UpdateScore()
    {
       //if (animationScript.wasCollected == true)
       // {
         
       // }
        StarCounter.text = "Stars: " + score;
    }
}


