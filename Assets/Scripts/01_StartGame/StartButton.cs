using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartButtonClicked()
    {
        SceneManager.LoadScene("02_Map");
    }
}
