using System.Collections;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    [SerializeField] Player player = default;
    [SerializeField] TextMeshProUGUI StarCounter = default;

    void Start()
    {
        StarCounter.text = "Stars: " + GameState.Score() + " / 3";
    }

    void Update()
    {
        if (player.activeInstructions)
        {
            StartCoroutine(PickInstructions());
        }
    }

    IEnumerator PickInstructions()
    {
        yield return new WaitForSeconds(3);
        player.activeInstructions = false;
    }

}
