using UnityEngine;

public abstract class CookableFood : Food, ICookable
{
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
