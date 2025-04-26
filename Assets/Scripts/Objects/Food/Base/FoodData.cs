using UnityEngine;
[CreateAssetMenu(fileName = "FoodData", menuName = "Scriptables/FoodData")]
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
}
