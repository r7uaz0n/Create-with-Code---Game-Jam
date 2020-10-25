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
        FromRoom3,
        LevelEnd
    }
    public static Transition lastUsedTransition = default;

    static string[] sceneNames =
    {
        "invalid index",
        "03_Room1",
        "02_Map",
        "03_Room2",
        "02_Map",
        "03_Room3",
        "02_Map",
        "04_End_Game"
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
            string scenenToLoad = sceneNames[(int)transition];
            UnityEngine.SceneManagement.SceneManager.LoadScene(scenenToLoad);
        }

    }
}
