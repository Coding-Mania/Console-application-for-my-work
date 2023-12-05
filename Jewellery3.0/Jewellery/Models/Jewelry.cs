namespace GoldJewelry.Models
{
    using Contracts;

    public class Jewelry : IJewelry
    {
        public Jewelry(string type, double weight, decimal price, string size)
        {
            this.Weight = weight;
            this.Type = type;
            this.Price = price;
            this.Size = size;
        }

        public string Type { get; private set; }

        public double Weight { get; private set; }

        public decimal Price { get; set; }

        public string Size { get; set; }
    }
}