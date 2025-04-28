using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] private List<FoodData> foodList = new();
    public Order GenerateOrder()
    {
        int dif = StatisticManager.difficulty;
        //dif = System.Math.Clamp(dif, 1, foodList.Count);
        //List<FoodData> orderFood = foodList.OrderBy(x => Random.value).Take(dif).ToList();

        List<FoodData> orderFood = new();
        for (int i = 0; i < dif; i++)
        {
            FoodData randomItem = foodList[Random.Range(0, foodList.Count)];
            orderFood.Add(randomItem);
        }
        return new Order(orderFood, GenerateID());
    }
    private string GenerateID()
    {
        string guid = System.Guid.NewGuid().ToString();
        Debug.Log(guid);

        foreach (Order order in FoodOrderManager.orders)
        {
            if (guid == order.id) GenerateID();
        }
        Debug.Log(guid);

        return guid;
    }
}
