using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] private List<FoodData> foodList = new();
    public Order GenerateOrder()
    {
        int dif = StatisticManager.difficulty;
        dif = System.Math.Clamp(dif, 1, foodList.Count);
        List<FoodData> orderFood = foodList.OrderBy(x => Random.value).Take(dif).ToList();
        return new Order(orderFood);
    }
}
