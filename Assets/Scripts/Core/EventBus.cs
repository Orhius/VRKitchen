using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EventBus
{
    public static event Action<Order> OnOrderIsCreated;
    public static void OrderIsCreated(Order order) => OnOrderIsCreated?.Invoke(order);

    public static event Action<List<FoodData>> OnOrderInTrigger;
    public static void OrderInTrigger(List<FoodData> foodData) => OnOrderInTrigger?.Invoke(foodData);

    public static event Action<string> OnOrderIsComplete;
    public static void OrderIsComplete(string id) => OnOrderIsComplete?.Invoke(id);
}
