using System.Collections;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    [SerializeField] Player player = default;

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
