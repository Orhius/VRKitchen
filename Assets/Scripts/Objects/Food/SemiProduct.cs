using System.Collections;
using UnityEngine;

public class SemiProduct : CookableFood
{
    public override void StartCooking()
    {
        StartCoroutine(Cooking());
    }
    public override void StopCooking()
    {
        StopAllCoroutines();
        cookingEffect.Stop();
    }
    IEnumerator Cooking()
    {
        cookingEffect.Play();
        yield return new WaitForSeconds(cookingTime);
        cookingEffect.Stop();
        Instantiate(cookedObject, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
