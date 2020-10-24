using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private string sceneName = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.gameObject.name)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
