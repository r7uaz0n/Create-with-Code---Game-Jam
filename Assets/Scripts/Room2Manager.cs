using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using System;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] private GameState.KeyId keyId = default;

    public int score;
    public TextMeshProUGUI StarCounter;
    public Player player;

    public GameObject Roominstructions;
    public GameObject Softstar;
    public AnimationScript animationScript;
    private Boolean scoreAdded;

    void Start()
    {
        //prevent star in room 2 from being collected twice
        if (GameState.checkKeyCollectionStatus(GameState.KeyId.Room2))
        {
            score = 1;
            Softstar.SetActive(false);
        }
        else if (!GameState.checkKeyCollectionStatus(GameState.KeyId.Room2))
        {
            score = 0;
            scoreAdded = false;
            Softstar.SetActive(true);
        }
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
        //Debug.Log(GameState.checkKeyCollectionStatus(GameState.KeyId.Room2));
    }
    IEnumerator PickInstructions()
    {
        yield return new WaitForSeconds(3);
        player.activeInstructions = false;
        Roominstructions.SetActive(false);
    }
    public void UpdateScore()
    {
        if (animationScript.wasCollected == true && scoreAdded == false)
        {
            score = score + 1;
            scoreAdded = true;
        }
        StarCounter.text = "Stars: " + score;

    }
}


