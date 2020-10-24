using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private GameObject room1ExitPlaceholder = default;
    [SerializeField] private GameObject room2ExitPlaceholder = default;
    [SerializeField] private GameObject room3ExitPlaceholder = default;

    private void Start()
    {
        switch (TransitionManager.lastUsedTransition)
        {
            case TransitionManager.Transition.FromRoom1:
                player.transform.position = room1ExitPlaceholder.transform.position;
                break;
            case TransitionManager.Transition.FromRoom2:
                player.transform.position = room2ExitPlaceholder.transform.position;
                break;
            case TransitionManager.Transition.FromRoom3:
                player.transform.position = room3ExitPlaceholder.transform.position;
                break;
            default:
                Debug.Log("Transition state not set (only valid at the beginning of the game).");
                break;
        }
    }
}
