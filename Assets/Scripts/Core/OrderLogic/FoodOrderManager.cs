using System.Collections.Generic;
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
    private List<Order> orders = new();

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
}
