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

    public static int Score()
    {
        bool[] keys = { didCollectKey1, didCollectKey2, didCollectKey3 };
        int score = 0;
        for (int i=0; i<keys.Length; i++)
        {
            score += keys[i] ? 1 : 0;
        }
        return score;
    }

    public static bool CheckKeyCollectionStatus(KeyId keyId)
    {
        bool wasAlreadyCollected = default;
        switch (keyId)
        {
            case KeyId.Room1:
                wasAlreadyCollected = didCollectKey1;
                break;
            case KeyId.Room2:
                wasAlreadyCollected = didCollectKey2;
                break;
            case KeyId.Room3:
                wasAlreadyCollected = didCollectKey3;
                break;
            default:
                UnityEngine.Debug.LogError("Transition state not set (only valid at the beginning of the game).");
                break;
        }
        return wasAlreadyCollected;
    }

    public static void CollectKeyWith(KeyId keyId)
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
