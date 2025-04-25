using UnityEngine;

public class Food : MonoBehaviour
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
}
