using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public enum Transition
    {
        NotSet,
        ToRoom1,
        FromRoom1,
        ToRoom2,
        FromRoom2,
        ToRoom3,
        FromRoom3
    }
    public static Transition lastUsedTransition = default;

    static string[] sceneNames =
    {
        "invalid index",
        "Room1_Justin_Dominic",
        "Map_Rick",
        "future room 2",
        "Map_Rick",
        "future room 3",
        "Map_Rick"
    };

    public static void TransitionTo(Transition transition)
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
