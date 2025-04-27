using UnityEngine;

public class OrdersCanvas : MonoBehaviour
{
    [SerializeField] private GameObject orderObject;
    [SerializeField] private Transform canvasTransform;

    private void OnEnable() => EventBus.OnOrderIsCreated += CreateOrderObject;
    private void OnDisable() => EventBus.OnOrderIsCreated -= CreateOrderObject;
    public void CreateOrderObject(Order order)
    {
        GameObject orderObj =  Instantiate(orderObject, canvasTransform);
        orderObj.GetComponent<OrderObject>().Init(order);
    }
}
