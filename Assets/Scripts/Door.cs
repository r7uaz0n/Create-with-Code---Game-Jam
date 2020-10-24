using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private TransitionManager.Transition transition = default;
    [SerializeField] private TransitionManager transitionManager = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.gameObject.name)
        {
            transitionManager.TransitionTo(transition);
        }
    }

}
