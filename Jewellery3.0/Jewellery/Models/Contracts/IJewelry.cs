namespace GoldJewelry.Models.Contracts
{
    public interface IJewelry
    {
        string Type { get; }

        double Weight { get; }

        decimal Price { get; }

        string Size { get; }
    }
}