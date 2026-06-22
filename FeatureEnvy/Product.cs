namespace FeatureEnvy;

public class Product
{
    private double _price;
    private bool _isDiscounted;
    
    public Product(double price, bool isDiscounted)
    {
        _price = price;
        _isDiscounted = isDiscounted;
    }

    private bool IsDiscounted()
    {
        return _isDiscounted;
    }

    public double FinalPrice
    {
        get
        {
            double finalPrice = this._price;

            if (this.IsDiscounted())
            {
                finalPrice = finalPrice * 0.8;
            }

            return finalPrice;
        }
    }
}