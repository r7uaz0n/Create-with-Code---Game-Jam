using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    //[SerializeField] private GameObject pick = default;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pick")
        {
            Destroy(gameObject);
        }
    }
}
