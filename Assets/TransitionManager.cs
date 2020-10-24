using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public enum Transition
    {
        NotSet = -1,
        ToRoom1 = 0,
        FromRoom1,
        ToRoom2,
        FromRoom2,
        ToRoom3,
        FromRoom3
    }
    public Transition lastUsedTransition = default;

    public string[] sceneNames =
    {
        "Room1_Justin_Dominic",
        "Map_Rick",
        "",
        "Map_Rick",
        "",
        "Map_Rick"
    };

    public void TransitionTo(Transition transition)
    {
        if (Transition.NotSet == transition)
        {
            Debug.LogError("TransitionState was not set on door.");
        }
        else
        {
            lastUsedTransition = transition;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames[(int)transition]);
        }
       
    }
}
