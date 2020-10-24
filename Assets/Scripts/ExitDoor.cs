using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameState.isExitRequirementMet())
        {
            Destroy(gameObject);
        }
    }
}
