using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private TransitionManager.Transition transition = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.gameObject.name)
        {
            TransitionManager.TransitionTo(transition);
        }
    }

}
