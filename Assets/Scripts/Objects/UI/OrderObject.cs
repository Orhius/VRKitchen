using UnityEngine;
using UnityEngine.UI;

public class OrderObject : MonoBehaviour
{
    [SerializeField] private Transform foodImagesPanel;
    [SerializeField] private GameObject foodImageObject;
    Order order;
    private void OnEnable() => EventBus.OnOrderIsComplete += CheckID;
    private void OnDisable() => EventBus.OnOrderIsComplete -= CheckID;
    public void Init(Order order)
    {
        this.order = order;
        foreach (FoodData foodData in order.foodInOrder)
        {
            GameObject foodImage = Instantiate(foodImageObject, foodImagesPanel);
            foodImage.GetComponent<Image>().sprite = foodData.FoodImage;
        }
    }
    private void CheckID(string id)
    {
        if(order.id == id) Destroy(gameObject);
    }
}
