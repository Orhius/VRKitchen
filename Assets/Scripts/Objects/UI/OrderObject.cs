using UnityEngine;
using UnityEngine.UI;

public class OrderObject : MonoBehaviour
{
    [SerializeField] private Transform foodImagesPanel;
    [SerializeField] private GameObject foodImageObject;
    public void Init(Order order)
    {
        foreach (FoodData foodData in order.foodInOrder)
        {
            GameObject foodImage = Instantiate(foodImageObject, foodImagesPanel);
            foodImage.GetComponent<Image>().sprite = foodData.FoodImage;
        }
    }
}
