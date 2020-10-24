using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private MainCamera mainCamera = default;
    [SerializeField] private GameObject room = default;

    private void OnTriggerStay(Collider other)
    {
        if ("Player" == other.gameObject.name)
        {
            mainCamera.PlayerInDoorToRoom(room);
        }
    }

}
