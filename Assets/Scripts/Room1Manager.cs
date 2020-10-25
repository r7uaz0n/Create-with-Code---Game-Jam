using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using System;

public class Room1Manager : MonoBehaviour
{
    [SerializeField] private GameState.KeyId keyId = default;

    public int score = GameState.Score();
    public TextMeshProUGUI StarCounter;
    public Player player;

    public GameObject Roominstructions;
    public GameObject Softstar;
    public GameObject Quarry;
    public GameObject PickPowerup;
    public AnimationScript animationScript;

    void Start()
    {
        bool key1CollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room1);
        Softstar.SetActive(!key1CollectionStatus);
        Quarry.SetActive(!key1CollectionStatus);
        PickPowerup.SetActive(!key1CollectionStatus);
    }

    private void Update()
    {
        UpdateScore();
        if (player.activeInstructions == true)
        {
            Room1SoundManager.instance.PlayPickUpgradeSound();
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
        StarCounter.text = "Stars: " + GameState.Score() + " / 3";
    }
}
