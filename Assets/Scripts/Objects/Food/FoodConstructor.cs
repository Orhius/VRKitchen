using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodConstructor : Food
{
    [SerializeField] private GameObject construct;

    [SerializeField] private List<RecipePartPair> recipePair = new();

    private Queue<string> recipe = new();
    private Queue<GameObject> recipeObjects = new();

    private void Start()
    {
        foreach (RecipePartPair item in recipePair)
        {
            recipe.Enqueue(item.recipePartName);
            recipeObjects.Enqueue(item.recipePartObjects);
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.GetComponent<Food>() != null && recipe.Peek() == obj.GetComponent<Food>().foodData.FoodName)
        {
            if(recipe.Count > 1)
            {
                recipe.Dequeue();
                GameObject part = recipeObjects.Dequeue();
                part.SetActive(true);
            }
            else
            {
                Instantiate(construct, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
            Destroy(obj.gameObject);
        }
    }
}
[Serializable]
public class RecipePartPair
{
    public string recipePartName;
    public GameObject recipePartObjects;
}
