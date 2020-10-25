using System.Collections;
using UnityEngine;
using TMPro;

public class Room1Manager : MonoBehaviour
{
    [SerializeField] Player player; 
    [SerializeField] StarCounter starCounter;
    [SerializeField] GameObject roominstructions;
    [SerializeField] GameObject softStar;
    [SerializeField] GameObject quarry;
    [SerializeField] GameObject pickPowerUp;
    [SerializeField] AnimationScript animationScript;

    void Start()
    {
        bool key1CollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room1);
        softStar.SetActive(!key1CollectionStatus);
        quarry.SetActive(!key1CollectionStatus);
        pickPowerUp.SetActive(!key1CollectionStatus);
    }

    private void Update()
    {
        UpdateScore();
        if (player.activeInstructions == true)
        {
            Room1SoundManager.instance.PlayPickUpgradeSound();
            roominstructions.SetActive(true);
            StartCoroutine(PickInstructions());
        }
    }

    IEnumerator PickInstructions()
    {
        yield return new WaitForSeconds(3);
        player.activeInstructions = false;
        roominstructions.SetActive(false);
    }

    public void UpdateScore()
    {
        starCounter.UpdateScoreText();
    }
}
