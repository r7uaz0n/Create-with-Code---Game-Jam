using TMPro;
using UnityEngine;

public class StarCounter : MonoBehaviour
{
    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        GetComponent<TextMeshProUGUI>().text = GameState.ScoreText();
    }
}
