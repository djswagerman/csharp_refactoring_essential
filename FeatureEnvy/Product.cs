namespace FeatureEnvy;

public class Product(double price, bool onSale)
{
    public double GetPrice()
    {
        return price;
    }

    public bool IsOnSale()
    {
        return onSale;
    }

    public double CalculateFinalPrice()
    {
        double finalPrice = this.GetPrice();

        if (this.IsOnSale())
        {
            finalPrice = finalPrice * 0.8;
        }

        return finalPrice;
    }
}