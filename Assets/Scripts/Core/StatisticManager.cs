using UnityEngine;

public static class StatisticManager
{
    [Range(0,4)] public static int difficulty { get; private set; } = 1;
}
