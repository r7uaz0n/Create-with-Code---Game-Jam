using System.Diagnostics;

public static class GameState
{
    public enum KeyId : int
    {
        NotSet,
        Room1,
        Room2,
        Room3
    }

    private static bool didCollectKey1 = false;
    private static bool didCollectKey2 = false;
    private static bool didCollectKey3 = false;

    public static void collectKeyWith(KeyId keyId)
    {
        switch (keyId)
        {
            case KeyId.Room1:
                didCollectKey1 = true;
                break;
            case KeyId.Room2:
                didCollectKey2 = true;
                break;
            case KeyId.Room3:
                didCollectKey3 = true;
                break;
            default:
                UnityEngine.Debug.LogError("Transition state not set (only valid at the beginning of the game).");
                break;
        }
    }
    
    public static bool isExitRequirementMet()
    {
        return didCollectKey1 && didCollectKey2 && didCollectKey3;
    }
}
