using System.Collections.Generic;

public class Order
{
    public List<FoodData> foodInOrder { get; private set; } = new();

    public Order(List<FoodData> foodInOrder)
    {
        this.foodInOrder = foodInOrder;
    }
}
