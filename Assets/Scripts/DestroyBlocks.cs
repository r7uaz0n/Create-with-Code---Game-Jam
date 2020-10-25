using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    //[SerializeField] private GameObject pick = default;
  //  public Room1SoundManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pick")
        {
            Destroy(gameObject);
            Room1SoundManager.instance.PlayCubeChisellingSound();
        }
    }
}
