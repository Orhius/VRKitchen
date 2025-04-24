using System.Collections.Generic;
using UnityEngine;

public class CookerTrigger : MonoBehaviour
{
    public List<ICookable> cookables { get; private set; } = new();
    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<ICookable>() != null)
        {
            ICookable cookable = col.GetComponent<ICookable>();
            cookables.Add(cookable);
            cookable.StartCooking();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<ICookable>() != null)
        {
            ICookable cookable = col.GetComponent<ICookable>();
            cookables.Remove(cookable);
            cookable.StopCooking();
        }
    }
}
