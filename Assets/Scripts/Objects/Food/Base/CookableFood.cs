using UnityEngine;

public abstract class CookableFood : MonoBehaviour, ICookable
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
    [SerializeField] protected float cookingTime;
    public float CookingTime
    {
        get { return cookingTime; }
        private set
        {
            if (value > 0) cookingTime = value;
        }
    }
    [SerializeField] protected GameObject cookedObject;
    [SerializeField] protected ParticleSystem cookingEffect;

    public abstract void StartCooking();
    public abstract void StopCooking();
}
