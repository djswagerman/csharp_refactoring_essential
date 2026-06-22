namespace FeatureEnvy;

public class Product(double price, bool isDiscounted)
{
    private bool IsDiscounted()
    {
        return isDiscounted;
    }

    public double FinalPrice
    {
        get
        {
            double finalPrice = price;

            if (this.IsDiscounted())
            {
                finalPrice = finalPrice * 0.8;
            }

            return finalPrice;
        }
    }
}