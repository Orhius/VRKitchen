using System;
using System.Collections.Generic;
[Serializable]
public struct Order
{
    public List<FoodData> foodInOrder { get; private set; }
    public string id { get; private set; }

    public Order(List<FoodData> foodInOrder, string id)
    {
        this.foodInOrder = foodInOrder;
        this.id = id;
    }
}
