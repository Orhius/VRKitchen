using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(OrderGenerator))]
public class FoodOrderManager : MonoBehaviour
{
    [SerializeField] private float orderGenTime = 30f;
    [SerializeField] private float minOrderGenTime = 16f;
    [SerializeField] private float timeDecreaseModifier = 2f;
    [SerializeField] private int difficultyCycle = 2;
    private float currentCycle;
    private float currentOrderGenTime;

    [SerializeField] private OrderGenerator orderGenerator;
    public static List<Order> orders { get; private set; } = new();
    private void OnEnable() => EventBus.OnOrderInTrigger += CompareOrders;
    private void OnDisable() => EventBus.OnOrderInTrigger -= CompareOrders;

    private void Start()
    {
        currentOrderGenTime = orderGenTime;
        currentCycle = difficultyCycle;

        Order order = orderGenerator.GenerateOrder();
        orders.Add(order);

        EventBus.OrderIsCreated(order);
    }
    private void LateUpdate()
    {
        currentOrderGenTime -= Time.deltaTime;

        if (currentOrderGenTime <= 0) CreateNewOrder();
    }
    [ContextMenu("CreateNewOrder")]
    private void CreateNewOrder()
    {
        if(orderGenTime > minOrderGenTime + timeDecreaseModifier) orderGenTime -= timeDecreaseModifier;
        currentOrderGenTime = orderGenTime;

        Order order = orderGenerator.GenerateOrder();
        orders.Add(order);

        EventBus.OrderIsCreated(order);

        currentCycle--;
        if (currentCycle <= 0)
        {
            currentCycle = difficultyCycle;
            StatisticManager.ChangeDifficulty();
        }
    }
    private void CompareOrders(List<FoodData> FoodData)
    {
        Debug.Log("ежлесово");
        foreach (Order order in orders)
        {
            if (order.foodInOrder.Count != FoodData.Count) break;

            var grouped1 = order.foodInOrder.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var grouped2 = FoodData.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            if(grouped1.All(pair => grouped2.TryGetValue(pair.Key, out var count) && count == pair.Value))
            {
                EventBus.OrderIsComplete(order.id);
                orders.Remove(order);

                Debug.Log("тихий дэн");
                return;
            }
        }
    }
}
