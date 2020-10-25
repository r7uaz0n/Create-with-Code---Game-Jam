using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using System;

public class Room1Manager : MonoBehaviour
{
    [SerializeField] private GameState.KeyId keyId = default;

    public int score;
    public TextMeshProUGUI StarCounter;
    public Player player;

    public GameObject Roominstructions;
    public GameObject Softstar;
    public GameObject Quarry;
    public GameObject PickPowerup;
    public AnimationScript animationScript;
    private Boolean scoreAdded; 

    void Start()
    {
        //prevent star in room 1 from being collected twice
        if (GameState.checkKeyCollectionStatus(GameState.KeyId.Room1))
        {
            score = 1;
            Softstar.SetActive(false);
            Quarry.SetActive(false);
            PickPowerup.SetActive(false);
        }
        else if (!GameState.checkKeyCollectionStatus(GameState.KeyId.Room1))
        {
            score = 0;
            scoreAdded = false;
            Softstar.SetActive(true);
            Quarry.SetActive(true);
            PickPowerup.SetActive(true);
        }
    }


    private void Update()
    {
        UpdateScore();
        //      Debug.Log(animationScript.wasCollected);
        if (player.activeInstructions == true)
        {
            Room1SoundManager.instance.PlayPickUpgradeSound();
            Roominstructions.SetActive(true);
            StartCoroutine(PickInstructions());
        }
       //Debug.Log(GameState.checkKeyCollectionStatus(GameState.KeyId.Room1));
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
            score = score +1;
            scoreAdded = true;
        }
        StarCounter.text = "Stars: " + score;

    }
}


