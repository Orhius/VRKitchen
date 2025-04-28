using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "foodData", menuName = "Scriptables/foodData")]
public class FoodData : ScriptableObject
{
    [SerializeField] protected string foodName;
    public string FoodName
    {
        get { return foodName; }
        private set
        {
            if (value != null) foodName = value;
        }
    }
    [SerializeField] protected Sprite foodImage;
    public Sprite FoodImage
    {
        get { return foodImage; }
        private set
        {
            if (value != null) foodImage = value;
        }
    }
}
