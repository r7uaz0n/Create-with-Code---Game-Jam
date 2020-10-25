using System.Collections;
using UnityEngine;
using TMPro;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] StarCounter starCounter;
    [SerializeField] GameObject roomInstructions;
    [SerializeField] GameObject softStar;
    [SerializeField] AnimationScript animationScript;

    void Start()
    {
        bool key2CollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room2);
        softStar.SetActive(!key2CollectionStatus);
    }

    private void Update()
    {
        UpdateScore();
        if (player.activeInstructions)
        {
            roomInstructions.SetActive(true);
            StartCoroutine(PickInstructions());
        }
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
