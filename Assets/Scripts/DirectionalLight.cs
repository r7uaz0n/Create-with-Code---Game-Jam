using UnityEngine;

public class DirectionalLight : MonoBehaviour
{
    // We only need the lighting while editing. It's not supposed to be used in the game.
    void Start()
    {
        Destroy(this.gameObject);
    }
}
