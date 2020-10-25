using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private int triggerId = default;
    [SerializeField] private Room3Manager roomThreeManager = default;

    private void OnCollisionEnter(Collision collision)
    {
        if (null != player && player.gameObject.name == collision.gameObject.name)
        {
            roomThreeManager.playerTouched(triggerId);
        }
    }
}
