public class GameState
{
    public static int keyCounter = 0;

    private static readonly int maximumKeys = 1;

    public bool isExitRequirementMet()
    {
        return keyCounter == maximumKeys;
    }
}
