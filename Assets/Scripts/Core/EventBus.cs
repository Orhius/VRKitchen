using System;
using UnityEngine;

public static class EventBus
{
    public static event Action<Order> OnOrderIsCreated;
    public static void OrderIsCreated(Order order) => OnOrderIsCreated?.Invoke(order);
}
