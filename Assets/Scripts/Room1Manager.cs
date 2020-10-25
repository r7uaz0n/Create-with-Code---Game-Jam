using System.Collections;
using UnityEngine;

public class Room1Manager : MonoBehaviour
{
    [SerializeField] Player player; 
    [SerializeField] StarCounter starCounter;
    [SerializeField] GameObject roomInstructions;
    [SerializeField] GameObject softStar;
    [SerializeField] GameObject quarry;
    [SerializeField] GameObject pickPowerUp;
    [SerializeField] GameObject invisibleBarrier;

    void Start()
    {
        bool key1CollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room1);
        softStar.SetActive(!key1CollectionStatus);
        quarry.SetActive(!key1CollectionStatus);
        pickPowerUp.SetActive(!key1CollectionStatus);
        invisibleBarrier.SetActive(!key1CollectionStatus);
        StartCoroutine(BlockPlayer());
    }

    private void Update()
    {
        UpdateScore();
        if (player.activeInstructions)
        {
            Room1SoundManager.instance.PlayPickUpgradeSound();
            roomInstructions.SetActive(true);
            StartCoroutine(PickInstructions());
        }
    }

    IEnumerator BlockPlayer()
    {
        yield return new WaitForSeconds(2f);
        invisibleBarrier.SetActive(false);
    }
    IEnumerator PickInstructions()
    {
        yield return new WaitForSeconds(3);
        player.activeInstructions = false;
        roomInstructions.SetActive(false);
    }

    public void UpdateScore()
    {
        starCounter.UpdateScoreText();
    }
}
