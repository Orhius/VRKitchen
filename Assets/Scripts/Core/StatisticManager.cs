using UnityEngine;

public static class StatisticManager
{
    [Range(1,4)] public static int difficulty { get; private set; } = 1;

    public static void ChangeDifficulty() => difficulty++;
}
