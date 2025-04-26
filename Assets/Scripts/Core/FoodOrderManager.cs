using System.Collections.Generic;
using UnityEngine;

public class FoodOrderManager : MonoBehaviour
{
    [SerializeField] private float orderGenTime = 30f;
    [SerializeField] private float minOrderGenTime = 16f;
    [SerializeField] private float timeDecreaseModifier = 2f;
    private float currentOrderGenTime;

    [SerializeField] private OrderGenerator orderGenerator;
    [SerializeField] private List<Order> orders = new();

    private void Start() => currentOrderGenTime = orderGenTime;
    private void LateUpdate()
    {
        currentOrderGenTime -= Time.deltaTime;

        if (currentOrderGenTime <= 0)
        {
            orderGenTime -= timeDecreaseModifier;
            currentOrderGenTime = orderGenTime;

            Order order = orderGenerator.GenerateOrder();
            orders.Add(order);
        }
    }
}
