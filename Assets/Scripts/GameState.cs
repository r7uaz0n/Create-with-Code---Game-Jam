public static class GameState
{
    public static bool didCollectKey1 = false;
    public static bool didCollectKey2 = false;
    public static bool didCollectKey3 = false;

    public static bool isExitRequirementMet()
    {
        return didCollectKey1 && didCollectKey2 && didCollectKey3;
    }
}
