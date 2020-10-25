using System.Collections;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] Player player = default;
    [SerializeField] StarCounter starCounter = default;
    [SerializeField] GameObject roomInstructions = default;
    [SerializeField] GameObject softStar = default;
    [SerializeField] GameObject directionalLight = default;
    [SerializeField] GameObject enemy1 = default;
    [SerializeField] GameObject enemy2 = default;
    [SerializeField] GameObject enemy3 = default;

    void Start()
    {
        CheckKeyStatus();
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
    void CheckKeyStatus()
    {
        bool keyCollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room2);
        enemy1.SetActive(!keyCollectionStatus);
        enemy2.SetActive(!keyCollectionStatus);
        enemy3.SetActive(!keyCollectionStatus);
        softStar.SetActive(!keyCollectionStatus);
        directionalLight.SetActive(keyCollectionStatus);
    }

}
